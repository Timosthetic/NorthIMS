using FeederProject.Models;
using Infrastructure.DealWithFile;
using Infrastructure.Helper.ConnectToPlc;
using Infrastructure.ReadWritePlc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using HslCommunication;
using HslCommunication.Profinet.Siemens;
using Infrastructure.Helper;
using Infrastructure.Model;
using Infrastructure.Dto.NewDto;
using Infrastructure.Dto.Login;
using Prism.Ioc;
using System.Collections;
using System.Threading;
using Serilog;
using Infrastructure.Dto;
using Newtonsoft.Json;
using Prism.Events;
using Infrastructure.Event;
using System.Windows;

namespace FeederProject.ViewModels.HardWorkViewModel
{
    public class RealTimeStation104ViewModel : BindableBase
    {
        private readonly IBaseService _baseService;
        /// <summary>
        /// 定义线程
        /// </summary>
        private Thread _Thread;
        private readonly object _locker = new object();

        public RealTimeStation104ViewModel(IContainerExtension container, IEventAggregator eventAggregator)

        {
            _baseService = container.Resolve<IBaseService>();
            ObPlcEvnet = new ObservableCollection<PlcEventModel>();


            ReadPlcEventExcel();
            SiemensS7Net = new SiemensS7Net(SiemensPLCS.S1500, Ip);


            Connect();
            DevStatus();
            ThreadStart();

        }

        #region 优化设备停线时间的统计  20221116
        public void ThreadStart()
        {
            if (_Thread == null)
            {
                _Thread = new Thread(WorkThread)
                {
                    Priority = ThreadPriority.Highest,
                    IsBackground = true
                };
                _Thread.Start();
            }
        }

        private  void WorkThread(object obj)
        {
            while (true)
            {
                lock (_locker)
                {
                    short devicestatus = SiemensS7Net.ReadInt16Async("DB5000.8").Result.Content;
                    DevcieStopTime(devicestatus);
                    Thread.Sleep(1000 * 1);
                }
            }
        }


        /// <summary>
        ///   //获取设备停机状态，计算加工工时
        /// </summary>
        /// <param name="status"></param>
        private void DevcieStopTime(short status)
        {
            try
            {
                DeviceStopDate deviceStopDate = new DeviceStopDate();
                if (!PUP && status != 0)
                {
                    PUP = true;
                    var re = AppDbContext.Db.Queryable<DeviceStopDate>().OrderBy(x => x.ID, SqlSugar.OrderByType.Desc).First();
                    if (re != null)
                    {
                        re.StopTime = DateTime.Now;
                        if (re.RunTime == null)
                        {
                            AppDbContext.Db.Updateable(re).ExecuteCommandAsync();
                        }
                        else
                        {
                            AppDbContext.Db.Insertable(re).ExecuteCommandAsync();
                        }
                    }
                    else
                    {
                        deviceStopDate.StopTime = DateTime.Now;
                        AppDbContext.Db.Insertable(deviceStopDate).ExecuteCommandAsync();
                    }

                }
                else if (PUP && status == 0)
                {
                    PUP = false;
                    var res = AppDbContext.Db.Queryable<DeviceStopDate>().Max(x => x.ID);
                    var device = AppDbContext.Db.Queryable<DeviceStopDate>().Where(x => x.ID == res).First();

                    device.RunTime = DateTime.Now;
                    if (device.RunTime > device.StopTime)
                    {
                        TimeSpan time = (TimeSpan)(device.RunTime - device.StopTime);
                        if (time.TotalSeconds > 0)
                        {
                            device.StopHours = time.TotalMinutes;
                        }
                        else
                        {
                            device.StopHours = 0;
                        }

                        AppDbContext.Db.Updateable(device).ExecuteCommandAsync();
                    }




                }


            }
            catch (Exception ex)
            {

                Log.Error($"处理设备状态时间异常,原因:{ex.Message}");
            }

        }


        #endregion
        #region Files

        private SiemensS7Net SiemensS7Net { get; set; }
        private short RSequenceID = 0;
        private short WSequenceID = 0;
        private string _ip = "192.168.0.13";
        /// <summary>
        /// 
        /// </summary>
        public string Ip
        {
            get { return _ip; }
            set { SetProperty(ref _ip, value); }
        }
        private bool _isConnectPlc = false;
        /// <summary>
        /// plc连接状态
        /// </summary>
        public bool IsConnectPlc
        {
            get { return _isConnectPlc; }
            set { SetProperty(ref _isConnectPlc, value); }
        }


        private ObservableCollection<PlcEventModel> _ObPlcEvnet;
        /// <summary>
        /// 工位实时流转状态
        /// </summary>
        public ObservableCollection<PlcEventModel> ObPlcEvnet
        {
            get { return _ObPlcEvnet; }
            set { SetProperty(ref _ObPlcEvnet, value); }
        }


        private ObservableCollection<PlcEventExcel> _plcEventExcle;
        /// <summary>
        /// PLC事件表
        /// </summary>
        public ObservableCollection<PlcEventExcel> PlcEventExcels
        {
            get { return _plcEventExcle; }
            set { SetProperty(ref _plcEventExcle, value); }
        }
        private ObservableCollection<Io_Vehicles_Bing> _vehBing;
        /// <summary>
        /// 载具绑定详情
        /// </summary>
        public ObservableCollection<Io_Vehicles_Bing> Vehicles_Bings
        {
            get { return _vehBing; }
            set { SetProperty(ref _vehBing, value); }
        }

        private List<PlcEventGroup> plcEventGroups = new List<PlcEventGroup>();
        #endregion
        #region Command
        private DelegateCommand _ConnectCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand ConnectCommand => _ConnectCommand ?? (_ConnectCommand = new DelegateCommand(() =>
        {
            Connect();
            IsDealEvent = new bool[100];
            SeqID = new short[100];
            Res = false;

        }));


        #endregion
        #region PLC连接
        /// <summary>
        /// plc连接
        /// </summary>
        private async void Connect()
        {
            await Task.Run(() =>
            {
                var res = SiemensS7Net.ConnectServerAsync();
                if (res.Result.IsSuccess)
                {
                    IsConnectPlc = true;
                }
                else
                {
                    IsConnectPlc = false;
                }


            });

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void Refresh()
        {
            var vehiclesInfos = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().ToList();
            Vehicles_Bings = new ObservableCollection<Io_Vehicles_Bing>(vehiclesInfos);
        }
        #endregion



        #region 公共区
        private void ReadPlcEventExcel()
        {


            if (DwFile.IsFileOpened("PLCEvent101.xls"))
            {
                // BoundMessageQueue.Enqueue("Excel文件处于打开状态");
            }
            else
            {

                LibExcel.ExcelHelper excelhelper = new LibExcel.ExcelHelper("PLCEvent101.xls");
                DataTable dt = excelhelper.ExcelToDataTable(null, true);
                if (dt == null) return;
                var res = LibExcel.ExcelHelper.GetList<PlcEventExcel>(dt);
                PlcEventExcels = new ObservableCollection<PlcEventExcel>(res);
            }
        }

        private void DevStatus()
        {
            plcEventGroups = PlcEventExcels.GroupBy(x => x.EventName)
                .Where(x => x.Key != null)
                .Select(group => new PlcEventGroup
                {
                    Key = group.Key,
                    Item = group.ToList()
                }).ToList();


            Task.Run(() => GetDeviceState());

        }


        private string _test;
        /// <summary>
        /// 
        /// </summary>
        public string Test
        {
            get { return _test; }
            set { SetProperty(ref _test, value); }
        }
        private int _heartbit = 0;
        private bool herat = false;

        private async Task GetDeviceState()
        {
            try
            {
                while (true)
                {
                    long res = SiemensS7Net.ReadInt64Async("DB5000.0").Result.Content;

                    bool[] bools = DataConversion.IntToBinaryBits64(res);
                 
                    bool Heartbeat = SiemensS7Net.ReadBoolAsync("DB5001.100.0").Result.Content;

                    if (!herat)
                    {
                        herat = true;
                        if (!Heartbeat)
                        {
                            IsConnectPlc = true;
                            _heartbit = 0;
                            await SiemensS7Net.WriteAsync("DB5001.100.0", true);
                        }
                        else
                        {
                            _heartbit += 1;
                            if (_heartbit > 5)
                            {
                                IsConnectPlc = false;
                            }
                        }
                        herat = false;
                    }

                   
                    EventCheck(bools);

                    DealNGpro();
                    await Task.Delay(200);
                }
            }
            catch (Exception ex)
            {
                IsConnectPlc = false;

            }

        }

        private List<short> Mst = new List<short>() { 11, 21, 31, 41, 51, 61, 71, 81, 91, 101, 111, 121 };
        /// <summary>
        /// 处理NG品 20220930
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void DealNGpro()
        {
            try
            {
                //首先清空要写入的数组
                short ok = 1;
                short ng = 2;
                var ngListok = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.ProMark == 1 || x.ProMark == 2).ToList();
                if (ngListok.Count > 0)
                {
                    foreach (var item in ngListok)

                    {
                        if (!string.IsNullOrEmpty(item.current_st))
                        {
                            int index = Mst.IndexOf(Convert.ToInt16(item.current_st));
                            if (index > -1)
                            {

                                if (item.ProMark == 1)
                                {
                                    SiemensS7Net.Write($"DB5001.{696 + 2 * index}", ok);
                                }
                                else if (item.ProMark == 2)
                                {
                                    SiemensS7Net.Write($"DB5001.{696 + 2 * index}", ng);
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Log.Error($"操作不良品标识写入plc异常，原因:{ex.Message}");
            }





        }

        /// <summary>
        /// 上升沿
        /// </summary>
        private bool PUP = false;

      
        private bool[] IsDealEvent = new bool[100];
        private short[] SeqID = new short[100];
        private bool Res = false;
        /// <summary>
        /// 事件触发处理
        /// </summary>
        /// <param name="eventtrigger"></param>
        private void EventCheck(bool[] eventtrigger)
        {
            try
            {
                if (!Res)
                {
                    Res = true;

                    for (int i = 0; i < eventtrigger.Length; i++)
                    {
                        if (eventtrigger[i])
                        {
                            if (!IsDealEvent[i])
                            {

                                var rwsID = plcEventGroups[i].Item.Where(x => x.PLC_PC == TagName.SequenceID).Single();
                                if (rwsID != null)
                                {
                                    OperateResult<short> operateResult = SiemensS7Net.ReadInt16(rwsID.AddressRead);
                                    if (operateResult.IsSuccess)
                                    {
                                        RSequenceID = operateResult.Content;
                                    }
                                    else
                                    {
                                        Log.Error($"读取事件触发失败,原因:{operateResult.Message}");
                                    }
                                    if (RSequenceID != SeqID[i])
                                    {
                                        IsDealEvent[i] = true;
                                        SeqID[i] = RSequenceID;
                                        DealWithPlcEventArgs dealWithPlcEventArgs = new DealWithPlcEventArgs() { EventName = plcEventGroups[i].Key, EventId = i };

                                        EventJob_DealWithPlc(dealWithPlcEventArgs);
                                        IsDealEvent[i] = false;
                                        WSequenceID = SiemensS7Net.ReadInt16(rwsID.AddressWrite).Content;
                                        if (SeqID[i] != WSequenceID)
                                        {
                                            WriteData(plcEventGroups[i].Key, TagName.SequenceID, SeqID[i]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Res = false;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"事件触发项处理失败,原因:{ex.Message}");
            }

        }
        #endregion
        #region 事件区
        private List<int> wmscode = new List<int>() { 321, 320, 319, 318, 317, 316, 315, 314, 313, 312, 311, 310, 309, 308, 307, 306, 305, 304, 303, 302, 301 };
        private void EventJob_DealWithPlc(DealWithPlcEventArgs dealWithPlcEvent)
        {

            try
            {
                //载具空闲事件
                if (dealWithPlcEvent.EventName == "RGV")
                {

                    var resTask = AppDbContext.Db.Queryable<WMS_TaskQueues>().First();
                    if (resTask != null)
                    {
                        if (resTask.task_status == 0)
                        {
                            if (!AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.current_st == resTask.st_num).Any())
                            {

                          
                            PlcEventModel plcEventModel = new PlcEventModel();
                            plcEventModel.FStartTime1 = DateTime.Now;
                            plcEventModel.FEvent = dealWithPlcEvent.EventName;
                            plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";

                            plcEventModel.FResultColor = "Green";

                            WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, Convert.ToInt16(resTask.wms_code));
                            plcEventModel.FResult = $"RGV取载具位置编号:{resTask.wms_code}";
                            plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                            ObPlcEvnet.Insert(0, plcEventModel);
                            string json = JsonConvert.SerializeObject(plcEventModel);
                            Log.Information($"事件名称:{dealWithPlcEvent.EventName}---{json}");
                            WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                            plcEventModel.SeqID = SeqID[dealWithPlcEvent.EventId];
                            IsDealEvent[dealWithPlcEvent.EventId] = false;
                            resTask.task_status = 1;
                            AppDbContext.Db.Updateable(resTask).ExecuteCommandAsync();

                            #region 载具空闲事件触发标记产品已处于虚拟上线状态 20221117
                          var MarkST=  AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.wms_code == resTask.wms_code).First();
                            MarkST.current_st = resTask.st_num;
                            AppDbContext.Db.Updateable(MarkST).ExecuteCommandAsync();
                                #endregion
                            }

                        }


                    }
                    else
                    {
                        WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 100);
                        WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                    }

                }

                if (dealWithPlcEvent.EventName == "ST14_缓存库载具校验")
                {
                    PlcEventModel plcEventModel = new PlcEventModel();
                    plcEventModel.FStartTime1 = DateTime.Now;
                    plcEventModel.FEvent = dealWithPlcEvent.EventName;
                    plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";
                    var rfid = RFID.GetRFIDReadInfo("ST14_下料");
                    if (string.IsNullOrEmpty(rfid.RfidInfo))
                    {
                        //没读出RFID信息回复plc报警编码  200
                        WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 200);
                        plcEventModel.FResultMark = $"未获取RFID信息，代码 200";
                        plcEventModel.FResult = $"未获取RFID信息，代码 200";
                        plcEventModel.FResultColor = "Red";

                    }
                    plcEventModel.FTrayName = rfid.RfidInfo;
                    Io_Vehicles_Bing io_Vehicles_Bing = Get_Vehicles_Bing(rfid.RfidInfo).Result;
                    short TargetSt = Convert.ToInt16(io_Vehicles_Bing.circulation_st.Split(",")[0]);
                    WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, TargetSt);
                    plcEventModel.FResultMark = $"由缓存库位置{io_Vehicles_Bing.wms_code}流转至工位{TargetSt}";
                    plcEventModel.FResult = $"由缓存库位置{io_Vehicles_Bing.wms_code}流转至工位{TargetSt}";
                    plcEventModel.FResultColor = "Green";

                    var clearTask = AppDbContext.Db.Queryable<WMS_TaskQueues>().Where(x => x.wms_code == io_Vehicles_Bing.wms_code).First();
                    if (clearTask != null)
                    {
                        AppDbContext.Db.Deleteable(clearTask).ExecuteCommandAsync();
                    }



                    if (TargetSt == 141)
                    {
                        io_Vehicles_Bing.pro_code = "";
                        io_Vehicles_Bing.material_code = "";
                        io_Vehicles_Bing.circulation_st = "";
                        io_Vehicles_Bing.current_st = "";
                        io_Vehicles_Bing.await_st = "";
                        io_Vehicles_Bing.serial_num = "";
                        io_Vehicles_Bing.wms_code = 0;
                        io_Vehicles_Bing.workorder = "";
                        io_Vehicles_Bing.ProMark = 0
                     ; AppDbContext.Db.Updateable(io_Vehicles_Bing).ExecuteCommandAsync();
                    }
                    else
                    {
                        io_Vehicles_Bing.current_st = TargetSt.ToString();
                        io_Vehicles_Bing.wms_code = 0;
                        io_Vehicles_Bing.ProMark = 0;
                        AppDbContext.Db.Updateable(io_Vehicles_Bing).ExecuteCommandAsync();
                    }




                    plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                    ObPlcEvnet.Insert(0, plcEventModel);
                    string json = JsonConvert.SerializeObject(plcEventModel);
                    Log.Information($"事件名称:{dealWithPlcEvent.EventName}---{json}");
                    WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                    plcEventModel.SeqID = SeqID[dealWithPlcEvent.EventId];
                    IsDealEvent[dealWithPlcEvent.EventId] = false;
                }
                if (dealWithPlcEvent.EventName == "ST13_上料")
                {

                    #region 事件开始处理
                    PlcEventModel plcEventModel = new PlcEventModel();
                    plcEventModel.FStartTime1 = DateTime.Now;
                    plcEventModel.FEvent = dealWithPlcEvent.EventName;
                    plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId.ToString()}";
                    //  Log.Error($"事件:{eventName}的线程ID{Thread.CurrentThread.ManagedThreadId}");
                    var rfid = RFID.GetRFIDReadInfo(dealWithPlcEvent.EventName);

                    if (string.IsNullOrEmpty(rfid.RfidInfo))
                    {
                        //没读出RFID信息回复plc报警编码  200
                        WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 200);
                        plcEventModel.FResultMark = $"未获取RFID信息，代码 200";
                        plcEventModel.FResult = $"未获取RFID信息，代码 200";
                        plcEventModel.FResultColor = "Red";
                    }
                    plcEventModel.FTrayName = rfid.RfidInfo;
                    Io_Vehicles_Bing io_Vehicles_Bing = Get_Vehicles_Bing(rfid.RfidInfo).Result;
                    if (string.IsNullOrEmpty(io_Vehicles_Bing.circulation_st))
                    {
                        WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 201);
                        plcEventModel.FResultMark = $"未获工位绑定信息，代码 201";
                        plcEventModel.FResult = $"未获工位绑定信息，代码 201";
                        plcEventModel.FResultColor = "Red";
                    }
                    List<string> res = new List<string>(io_Vehicles_Bing.await_st.Split(","));
                    //pan duan biao qian shi fou you xin xi 
                    if (res.Count < 1)
                    {
                        WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 200);

                    }
                    #endregion
                    #region 缓存库入库处理  工单的首工位的主料工位存在托盘即进入缓存库，辅料工位满足工位最大存储数量后则进入缓存库
                    short inout = ReadData(dealWithPlcEvent.EventName, TagName.InOutState);
                    if (inout == 2)
                    {


                        short TargetSt = Convert.ToInt16(res[0]);

                      
                        //判断主料还是辅料  主料 1  辅料2
                        var ms = TargetSt % 10;
                        //载具进入缓存库还是上线生产,如果目的工位已存在托盘，就进入缓存库
                        var placeholder = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.current_st == TargetSt.ToString()).Count();


                        List<int> wmscodeNow = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Select(x => x.wms_code).ToList();
                        List<int> last = wmscode.Where(a => !wmscodeNow.Exists(t => a.Equals(t))).ToList();
                        if ((placeholder > 0 && ms == 1)|| (placeholder == 3 && ms == 2))
                        {

                            if (last.Count > 0)
                            {
                                List<short> buffer = new List<short>(SiemensS7Net.ReadInt16("DB5000.400", 21).Content);


                                var wmsbuffer = last.Where(a => !buffer.Exists(t => a.Equals(t))).ToList();
                                if (wmsbuffer.Count > 0)
                                {
                                    WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, Convert.ToInt16(wmsbuffer[0]));
                                    io_Vehicles_Bing.wms_code = wmsbuffer[0];
                                    plcEventModel.FResultMark = $"目的缓存位:{Convert.ToInt16(wmsbuffer[0])}";
                                    plcEventModel.FResult = $"目的缓存位:{Convert.ToInt16(wmsbuffer[0])}";
                                    plcEventModel.FResultColor = "Green";
                                }
                                else
                                {
                                    WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, Convert.ToInt16(200));
                                    plcEventModel.FResultMark = $"缓存库已满:{Convert.ToInt16(200)}";
                                    plcEventModel.FResult = $"缓存库已满:{Convert.ToInt16(200)}";
                                    plcEventModel.FResultColor = "Green";
                                }
                            }
                            else
                            {
                                WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, Convert.ToInt16(200));
                                plcEventModel.FResultMark = $"缓存库已满:{Convert.ToInt16(200)}";
                                plcEventModel.FResult = $"缓存库已满:{Convert.ToInt16(200)}";
                                plcEventModel.FResultColor = "Green";

                            }

                        }
                       
                        else
                        {
                            WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, TargetSt);
                            plcEventModel.FResultMark = $"目的工位:{TargetSt}";
                            plcEventModel.FResult = $"目的工位:{TargetSt}";
                            plcEventModel.FResultColor = "Green";
                            io_Vehicles_Bing.current_st = TargetSt.ToString();
                        }
                        UpdateVelBing(io_Vehicles_Bing);

                    }
                    #endregion
                    #region 事件结束处理
                    WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                    plcEventModel.SeqID = SeqID[dealWithPlcEvent.EventId];
                    plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                    ObPlcEvnet.Insert(0, plcEventModel);
                    string json = JsonConvert.SerializeObject(plcEventModel);
                    Log.Information($"事件名称:{dealWithPlcEvent.EventName}---{json}");
                    IsDealEvent[dealWithPlcEvent.EventId] = false;
                    if (ObPlcEvnet.Count > 2000)
                    {
                        ObPlcEvnet.Clear();
                    }
                    #endregion

                }

                else if (dealWithPlcEvent.EventName == "ST14_下料")
                {
                    #region 事件开始处理
                    PlcEventModel plcEventModel = new PlcEventModel();
                    plcEventModel.FStartTime1 = DateTime.Now;
                    plcEventModel.FEvent = dealWithPlcEvent.EventName;
                    plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";
                    //  Log.Error($"事件:{eventName}的线程ID{Thread.CurrentThread.ManagedThreadId}");
                    var rfid = RFID.GetRFIDReadInfo("ST14_下料");
                    if (string.IsNullOrEmpty(rfid.RfidInfo))
                    {
                        //没读出RFID信息回复plc报警编码  200
                        WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 200);
                        plcEventModel.FResultMark = $"未获取RFID信息，代码 200";
                        plcEventModel.FResult = $"未获取RFID信息，代码 200";
                        plcEventModel.FResultColor = "Red";
                    }
                    plcEventModel.FTrayName = rfid.RfidInfo;
                    Io_Vehicles_Bing io_Vehicles_Bing = Get_Vehicles_Bing(rfid.RfidInfo).Result;
                    #endregion

                    if (io_Vehicles_Bing != null)
                    {


                        //统计下线数量

                        var po = AppDbContext.Db.Queryable<po_info>().Where(x => x.工单号 == io_Vehicles_Bing.workorder).Single();
                        if (po != null)
                        {
                            po.已完工数量 += 1;
                            //20220920  
                            if (po.已完工数量 == po.工单数量)
                            {
                                po.实际完工日期 = DateTime.Now.ToString();
                                po.工单状态 = "已完成";
                            }
                            AppDbContext.Db.Updateable(po).ExecuteCommandAsync();
                        }
                        short inout = ReadData(dealWithPlcEvent.EventName, TagName.InOutState);
                        if (inout == 1)
                        {
                            plcEventModel.FResultMark = $"进站工位:141";
                            plcEventModel.FResult = $"进站工位:141";
                            plcEventModel.FResultColor = "Green";
                            io_Vehicles_Bing.current_st = "";
                            io_Vehicles_Bing.await_st = "";
                            io_Vehicles_Bing.circulation_st = "";
                            io_Vehicles_Bing.material_code = "";
                            io_Vehicles_Bing.pro_code = "";
                            io_Vehicles_Bing.serial_num = "";
                            io_Vehicles_Bing.wms_code = 0;
                            io_Vehicles_Bing.workorder = "";
                            //载具信息解除绑定 回复编码100
                            WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 100);

                        }
                        UpdateVelBing(io_Vehicles_Bing);
                    }

                    plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                    WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                    plcEventModel.SeqID = SeqID[dealWithPlcEvent.EventId];
                    ObPlcEvnet.Insert(0, plcEventModel);
                    string json = JsonConvert.SerializeObject(plcEventModel);
                    Log.Information($"事件名称:{dealWithPlcEvent.EventName}---{json}");
                    if (ObPlcEvnet.Count > 2000)
                    {
                        ObPlcEvnet.Clear();
                    }

                    IsDealEvent[dealWithPlcEvent.EventId] = false;
                }
                else if (dealWithPlcEvent.EventName != "ST14_缓存库载具校验" && !dealWithPlcEvent.EventName.Contains("Release") && dealWithPlcEvent.EventName != "RGV")
                {

                    short inout = ReadData(dealWithPlcEvent.EventName, TagName.InOutState);

                    if (inout == 1)
                    {
                        InStation(dealWithPlcEvent.EventName, dealWithPlcEvent.EventId);

                    }
                    else if (inout == 2)
                    {
                        OutStation(dealWithPlcEvent.EventName, dealWithPlcEvent.EventId);

                    }
                    else
                    {
                        PlcEventModel plcEventModel = new PlcEventModel();
                        plcEventModel.FEvent = dealWithPlcEvent.EventName;
                        plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";
                        plcEventModel.FResultMark = $"未接收到进出站标识";
                        plcEventModel.FResult = $"未接收到进出站标识";
                        plcEventModel.FResultColor = "Red";
                        plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                        WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                        plcEventModel.SeqID = SeqID[dealWithPlcEvent.EventId];
                        ObPlcEvnet.Insert(0, plcEventModel);
                        string json = JsonConvert.SerializeObject(plcEventModel);
                        Log.Information($"事件名称:{dealWithPlcEvent.EventName}---{json}");
                        if (ObPlcEvnet.Count > 2000)
                        {
                            ObPlcEvnet.Clear();
                        }

                        IsDealEvent[dealWithPlcEvent.EventId] = false;
                    }

                }
                else if (dealWithPlcEvent.EventName.Contains("Release"))
                {
                    PlcEventModel plcEventModel = new PlcEventModel();
                    plcEventModel.FStartTime1 = DateTime.Now;
                    var st = dealWithPlcEvent.EventName.Split("_")[0];


                    #region 避免托盘全部下线导致托盘无处存放，


                    var ms = Convert.ToInt16(st) % 10;
                    //增加放行按钮事件触发将辅料工位数据清空
                    if (ms == 2)
                    {
                        var clearst = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.current_st == st).ToList();
                        if (clearst.Count > 0)
                        {
                            foreach (var item in clearst)
                            {
                                item.current_st = "";
                                AppDbContext.Db.Updateable(item).ExecuteCommand();
                            }
                        }
                    }
                    #endregion

                    #region 产品加工完成放行触发时间，用来计算加工工时
                    var serial = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.current_st == st).Select(x => x.serial_num).First();
                    if (serial != null)
                    {

                        var dttrack = AppDbContext.Db.Queryable<dt_Trace_Track>().Where(x => x.Serial_num == serial && x.Station == Convert.ToInt32(st)).First();
                        if (dttrack != null)
                        {
                            dttrack.OutWait_Station = DateTime.Now;
                            AppDbContext.Db.Updateable(dttrack).ExecuteCommandAsync();
                            plcEventModel.FResult = $"等待时间:{dttrack.OutWait_Station}";
                        }

                    }
                    #endregion


                    #region 产品NG标记
                    //载具NG处理
                    var ngcout = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.current_st == st).First();
                    if (ngcout != null)
                    {
                        //产品放行标记为 禁止标记产品为NG
                        ngcout.ProMark = 3;

                        AppDbContext.Db.Updateable(ngcout).ExecuteCommandAsync();
                    }
                    #endregion


                    #region 事件状态处理
                    plcEventModel.FResultColor = "Green";
                    plcEventModel.FEvent = dealWithPlcEvent.EventName;
                    plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";
                    plcEventModel.SeqID = SeqID[dealWithPlcEvent.EventId];
                    ObPlcEvnet.Insert(0, plcEventModel);
                    WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                    IsDealEvent[dealWithPlcEvent.EventId] = false;
                    #endregion

                }

            }
            catch (Exception ex)
            {
                #region 异常处理
                PlcEventModel plcEventModel = new PlcEventModel();
                plcEventModel.FEvent = dealWithPlcEvent.EventName;
                plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";
                WriteData(dealWithPlcEvent.EventName, TagName.ResultCode, 200);
                plcEventModel.FResultMark = $"处理事件{dealWithPlcEvent.EventName}异常，代码 201";
                plcEventModel.FResult = $"处理事件{dealWithPlcEvent.EventName}异常，代码 201";
                plcEventModel.FResultColor = "Red";
                plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                WriteData(dealWithPlcEvent.EventName, TagName.SequenceID, SeqID[dealWithPlcEvent.EventId]);
                plcEventModel.SeqID = SeqID[dealWithPlcEvent.EventId];
                ObPlcEvnet.Insert(0, plcEventModel);
                Log.Error($"plc事件操作异常：{ex.Message}");
                #endregion


            }
        }
        /// <summary>
        /// 进站事件
        /// </summary>
        /// <param name="eventanme"></param>
        /// <param name="eventid"></param>
        private async void InStation(string eventanme, int eventid)
        {


            try
            {
                PlcEventModel plcEventModel = new PlcEventModel();
                plcEventModel.FStartTime1 = DateTime.Now;
                plcEventModel.FEvent = eventanme;
                plcEventModel.FStartTime1 = DateTime.Now;
                plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";
                var rfid = RFID.GetRFIDReadInfo(eventanme);
                if (string.IsNullOrEmpty(rfid.RfidInfo))
                {
                    //没读出RFID信息回复plc报警编码  200
                    WriteData(eventanme, TagName.ResultCode, 200);
                    plcEventModel.FResultMark = $"未获取RFID信息，代码 200";
                    plcEventModel.FResult = $"未获取RFID信息，代码 200";
                    plcEventModel.FResultColor = "Red";
                    WriteData(eventanme, TagName.SequenceID, SeqID[eventid]);
                }
                plcEventModel.FTrayName = rfid.RfidInfo;
                Io_Vehicles_Bing io_Vehicles_Bing = Get_Vehicles_Bing(rfid.RfidInfo).Result;
                if (io_Vehicles_Bing != null)
                {

                    List<string> res = new List<string>(io_Vehicles_Bing.await_st.Split(","));
                    if (res.Count > 0)
                    {
                        short TargetSt = Convert.ToInt16(res[0]);

                        WriteData(eventanme, TagName.ResultCode, TargetSt);

                        if (rfid.StationInfo == TargetSt)
                        {
                            plcEventModel.FResult = $"已进站工位:{TargetSt}-IN:下一站工位:{res[1]}-IN";
                            io_Vehicles_Bing.current_st = TargetSt.ToString();


                            WriteData(eventanme, TagName.NextStation, Convert.ToInt16(res[1]));

                            plcEventModel.FResultColor = "Green";
                            if (io_Vehicles_Bing.serial_num.Substring(0, 1) == "M")
                            {
                                //防止重复插入数据 20220913
                                var count = await AppDbContext.Db.Queryable<dt_Trace_Track>().Where(x => x.Serial_num == io_Vehicles_Bing.serial_num && x.Station == TargetSt).FirstAsync();
                                if (count == null)
                                {
                                    dt_Trace_Track dt_Trace_Track = new dt_Trace_Track()
                                    {
                                        Serial_num = io_Vehicles_Bing.serial_num,
                                        IN_Station = DateTime.Now,
                                        Station = TargetSt,
                                        WorkOrder = io_Vehicles_Bing.workorder,
                                        TagSerialnum = io_Vehicles_Bing.TagSerialnum,
                                    };
                                    await AppDbContext.Db.Insertable(dt_Trace_Track).ExecuteCommandAsync();
                                    plcEventModel.FResultMark = $"进站时间:{dt_Trace_Track.IN_Station}-IN";
                                }
                                else
                                {
                                    count.IN_Station = DateTime.Now;
                                    await AppDbContext.Db.Updateable(count).ExecuteCommandAsync();
                                    plcEventModel.FResultMark = $"进站时间:{count.IN_Station}-IN";
                                }

                            }


                        }
                        else
                        {
                            plcEventModel.FResultMark = $"进站目的工位:{TargetSt}-IN";
                            plcEventModel.FResult = $"进站目的工位:{TargetSt}-IN";
                            plcEventModel.FResultColor = "Green";

                        }

                    }
                    else
                    {
                        Log.Error($"当前托盘{rfid.RfidInfo}内的数据异常，流转数据丢失");
                    }

                    //产品进站标记ok
                    io_Vehicles_Bing.ProMark = 1;

                    UpdateVelBing(io_Vehicles_Bing);


                }
                if (ObPlcEvnet.Count > 2000)
                {
                    ObPlcEvnet.Clear();
                }

                WriteData(eventanme, TagName.SequenceID, SeqID[eventid]);

                plcEventModel.SeqID = SeqID[eventid];
                plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                ObPlcEvnet.Insert(0, plcEventModel);
                string json = JsonConvert.SerializeObject(plcEventModel);
                Log.Information($"事件名称:{eventanme}---{json}");
                IsDealEvent[eventid] = false;

            }
            catch (Exception ex)
            {

                throw;
            }


        }
        /// <summary>
        /// 出站事件
        /// </summary>
        /// <param name="eventanme"></param>
        /// <param name="eventid"></param>
        private async void OutStation(string eventanme, int eventid)
        {


            try
            {
                PlcEventModel plcEventModel = new PlcEventModel();
                plcEventModel.FStartTime1 = DateTime.Now;
                plcEventModel.FStartTime1 = DateTime.Now;
                plcEventModel.FEvent = eventanme;
                plcEventModel.FName = $"处理线程—— {Thread.CurrentThread.ManagedThreadId}";
                // Log.Error($"事件:{eventanme}的线程ID{Thread.CurrentThread.ManagedThreadId}");
                var rfid = RFID.GetRFIDReadInfo(eventanme);
                if (string.IsNullOrEmpty(rfid.RfidInfo))
                {
                    //没读出RFID信息回复plc报警编码  200
                    WriteData(eventanme, TagName.ResultCode, 200);
                    plcEventModel.FResultMark = $"未获取RFID信息，代码 200";
                    plcEventModel.FResult = $"未获取RFID信息，代码 200";
                    plcEventModel.FResultColor = "Red";

                }
                plcEventModel.FTrayName = rfid.RfidInfo;
                Io_Vehicles_Bing io_Vehicles_Bing = Get_Vehicles_Bing(rfid.RfidInfo).Result;
                if (io_Vehicles_Bing != null)
                {
                    List<string> res = new List<string>(io_Vehicles_Bing.await_st.Split(","));

                    var dtTrace = AppDbContext.Db.Queryable<dt_Trace_Track>().Where(x => x.Serial_num == io_Vehicles_Bing.serial_num && x.Station == Convert.ToInt32(res[0])).First();
                    if (dtTrace != null)
                    {
                        dtTrace.Out_Station = DateTime.Now;
                        double stopiw = 0;
                        double stopwo = 0;
                        if (dtTrace.IN_Station != null && dtTrace.OutWait_Station != null)
                        {
                            //进站与放行按钮触发之间线体停止计时
                            var iw = AppDbContext.Db.Queryable<DeviceStopDate>().Where(x => x.StopTime > dtTrace.IN_Station && x.RunTime < dtTrace.OutWait_Station).ToList();

                            TimeSpan ph = (TimeSpan)(dtTrace.OutWait_Station - dtTrace.IN_Station);
                            if (iw.Count > 0)
                            {
                                foreach (var item in iw)
                                {
                                    stopiw += item.StopHours;
                                }
                                dtTrace.Processing_Hours = ph.TotalMinutes - stopiw;
                            }
                            else
                            {

                                dtTrace.Processing_Hours = ph.TotalMinutes;
                            }
                            //放行按钮触发与出站之间计时
                            var wo = AppDbContext.Db.Queryable<DeviceStopDate>().Where(x => x.StopTime > dtTrace.OutWait_Station && x.RunTime < dtTrace.Out_Station).ToList();
                            TimeSpan wh = (TimeSpan)(dtTrace.Out_Station - dtTrace.OutWait_Station);
                            if (wo.Count > 0)
                            {
                                foreach (var item in wo)
                                {
                                    stopwo += item.StopHours;
                                }
                                dtTrace.Wait_Hours = wh.TotalMinutes - stopwo;
                            }
                            else
                            {


                                dtTrace.Wait_Hours = wh.TotalMinutes;
                            }
                            var kanbanlogin = AppDbContext.Db.Queryable<StaffLogin>().Where(x => x.StationID == Convert.ToInt32(res[0])).Single();
                            if (kanbanlogin != null)
                            {
                                kanbanlogin.Efficiency = double.Parse(dtTrace.Processing_Hours.ToString("0.0"));
                                await AppDbContext.Db.Updateable(kanbanlogin).ExecuteCommandAsync();
                                //员工登录工位记录加工工时  20220913
                                dtTrace.StaffNum = kanbanlogin.StaffNum;
                                dtTrace.StaffName = kanbanlogin.StaffName;
                                await AppDbContext.Db.Updateable(dtTrace).ExecuteCommandAsync();
                            }
                            double sumPh = 0;
                            double sumWh = 0;
                            //平均加工工时  20220913
                            var hours = await AppDbContext.Db.Queryable<dt_Trace_Track>().Where(x => x.WorkOrder == io_Vehicles_Bing.workorder && x.Station == Convert.ToInt32(res[0])).ToListAsync();
                            if (hours.Count > 0)
                            {
                                foreach (var item in hours)
                                {
                                    sumPh += item.Processing_Hours;
                                    sumWh += item.Wait_Hours;
                                }
                                var kanban = AppDbContext.Db.Queryable<kanBan_WorkingHours>().Where(x => x.StId == Convert.ToInt32(res[0])).Single();
                                if (kanban != null)
                                {
                                    kanban.Processing_Hours = double.Parse((sumPh / hours.Count).ToString("0.0"));
                                    kanban.Wait_Hours = double.Parse((sumWh / hours.Count).ToString("0.0"));
                                    await AppDbContext.Db.Updateable(kanban).ExecuteCommandAsync();
                                }
                                plcEventModel.FResultMark = $"出站时间:{dtTrace.Out_Station}-OUT";
                            }
                        }




                    }


                    //出站标记
                    if (io_Vehicles_Bing.ProMark != 4)
                    {
                        short TargetSt = Convert.ToInt16(res[1]);

                        if (io_Vehicles_Bing.circulation_st.Split(",")[0] == io_Vehicles_Bing.current_st)
                        {
                            WmsBuffer(io_Vehicles_Bing);
                        }


                        WriteData(eventanme, TagName.ResultCode, TargetSt);
                        WriteData(eventanme, TagName.NextStation, TargetSt);

                        plcEventModel.FResult = $"下一站站工位:{TargetSt}-OUT";

                        plcEventModel.FResultColor = "Green";
                        io_Vehicles_Bing.current_st = "";
                        res.RemoveAt(0);
                        io_Vehicles_Bing.await_st = string.Join(",", res.ToArray());
                        io_Vehicles_Bing.ProMark = 4;
                        UpdateVelBing(io_Vehicles_Bing);


                    }




                }
                if (ObPlcEvnet.Count > 2000)
                {
                    ObPlcEvnet.Clear();
                }

                WriteData(eventanme, TagName.SequenceID, SeqID[eventid]);

                plcEventModel.FDoTime = (DateTime.Now - plcEventModel.FStartTime).TotalMilliseconds;
                plcEventModel.SeqID = SeqID[eventid];
                ObPlcEvnet.Insert(0, plcEventModel);
                string json = JsonConvert.SerializeObject(plcEventModel);
                Log.Information($"事件名称:{eventanme}---{json}");
                IsDealEvent[eventid] = false;
            }
            catch (Exception ex)
            {

                throw;
            }



        }


        /// <summary>
        ///产品出站取载具20221013
        /// </summary>
        /// <param name="workorser">工单号</param>
        private void WmsBuffer(Io_Vehicles_Bing io_Vehicles_Bing)
        {

            try
            {
                int ST = Convert.ToInt32(io_Vehicles_Bing.circulation_st.Split(",")[0]);
                var ms = ST % 10;

                if (ms == 1)
                {
                    var M_code = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.wms_code > 0 && x.circulation_st == io_Vehicles_Bing.circulation_st).First();
                    if (M_code != null)
                    {
                        bool isexiste = AppDbContext.Db.Queryable<WMS_TaskQueues>().Where(x => x.wms_code == M_code.wms_code).Any();
                        if (!isexiste)
                        {
                            WMS_TaskQueues wMS_TaskQueues = new WMS_TaskQueues()
                            {
                                st_num = ST.ToString(),
                                wms_code = M_code.wms_code,
                                task_status = 0,
                                tag_order = M_code.workorder,
                                isexists_MS = 1,

                            };
                            AppDbContext.Db.Insertable(wMS_TaskQueues).ExecuteCommand();
                        }
                    }

                }

                else if (ms == 2)
                {

                    if (AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.current_st == ST.ToString()).Count() < 2)
                    {
                        var S_code = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.wms_code > 0 && x.circulation_st == io_Vehicles_Bing.circulation_st)
                            .Take(3).ToList();
                        if (S_code.Count > 0)
                        {
                            foreach (var item in S_code)
                            {
                                bool isexiste = AppDbContext.Db.Queryable<WMS_TaskQueues>().Where(x => x.wms_code == item.wms_code).Any();
                                if (!isexiste)
                                {
                                    WMS_TaskQueues wMS_TaskQueues = new WMS_TaskQueues()
                                    {
                                        st_num = ST.ToString(),
                                        wms_code = item.wms_code,
                                        task_status = 0,
                                        tag_order = item.workorder,
                                        isexists_MS = 1,

                                    };
                                    AppDbContext.Db.Insertable(wMS_TaskQueues).ExecuteCommand();
                                }
                            }
                        }
                    }


                }


            }
            catch (Exception ex)
            {
                Log.Error($"缓存库取主料载具异常:{ex.Message}");

            }

        }
        /// <summary>
        /// 获取此载具ID的绑定信息
        /// </summary>
        /// <param name="VehiclesCode"></param>
        /// <returns></returns>
        private async Task<Io_Vehicles_Bing> Get_Vehicles_Bing(string VehiclesCode)
        {
            var res = await _baseService.GetVelBingAsync(VehiclesCode);
            var ress = (Io_Vehicles_Bing)res.Result;

            return ress;

        }


        /// <summary>
        /// 更新载具绑定信息
        /// </summary>
        /// <param name="io_Vehicles_Bing"></param>
        private async void UpdateVelBing(Io_Vehicles_Bing io_Vehicles_Bing)
        {
            var res = await _baseService.UpdateVelBingAsync(io_Vehicles_Bing);
        }


        #endregion


        #region Excel
        private short ReadData(string evenName, string plcTopcTitle)
        {
            try
            {
                var title = plcEventGroups
                 .Where(x => x.Key == evenName)
                 .Select(x => x.Item.Where(x => x.PLC_PC == plcTopcTitle).Single()).Single();
                OperateResult<short> operateResult = SiemensS7Net.ReadInt16(title.AddressRead);
                if (operateResult.IsSuccess)
                {
                    return operateResult.Content;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw;
            }






        }


        private void WriteData(string evenName, string pctoplcTitle, short data)
        {
            bool writestate = true;
            var title = plcEventGroups
               .Where(x => x.Key == evenName)
               .Select(x => x.Item.Where(x => x.PC_PLC == pctoplcTitle).Single()).Single();
            SiemensS7Net.Write(title.AddressWrite, data);
            do
            {

                OperateResult<short> operateResult = SiemensS7Net.ReadInt16(title.AddressWrite);
                if (operateResult.IsSuccess)
                {
                    if (operateResult.Content == data)
                    {
                        writestate = false;
                    }
                    else
                    {
                        writestate = true;
                    }
                }
                else
                {
                    writestate = true;
                }

            } while (writestate);



        }
        #endregion

    }
}
