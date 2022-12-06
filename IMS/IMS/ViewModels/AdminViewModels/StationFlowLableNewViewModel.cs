 using Infrastructure.Dto;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using PrintServer;
using Serilog;
using System.Threading.Tasks;

namespace IMS.ViewModels.AdminViewModels
{
    public class StationFlowLableNewViewModel:BindableBase
    {
        public StationFlowLableNewViewModel()
        {
            Refresh();
            Mmte();
            BtnPrintIsenable = false;
        }
        #region Files

        PrintServiceClient printServiceClient = new PrintServiceClient();
        private ObservableCollection<po_info> _planCode;
        /// <summary>
        /// 项目/计划  编号集合
        /// </summary>
        public ObservableCollection<po_info> PlanCodes
        {
            get { return _planCode; }
            set { SetProperty(ref _planCode, value); }
        }


        private po_info _planInfo;
        /// <summary>
        /// 选中的工单项
        /// </summary>
        public po_info PlanInfo
        {
            get { return _planInfo; }
            set { SetProperty(ref _planInfo, value); }
        }


        private ObservableCollection<DataTraceability> _MprintNode;
        /// <summary>
        /// 主 料打印数据
        /// </summary>
        public ObservableCollection<DataTraceability> MPrintNodes
        {
            get { return _MprintNode; }
            set { SetProperty(ref _MprintNode, value); }
        }

        private ObservableCollection<DataTraceability> _SprintNode;
        /// <summary>
        /// 辅 料打印数据
        /// </summary>
        public ObservableCollection<DataTraceability> SPrintNodes
        {
            get { return _SprintNode; }
            set { SetProperty(ref _SprintNode, value); }
        }
        private bool _btnPrintIsenable;
        /// <summary>
        /// 是否具备打印条件
        /// </summary>
        public bool BtnPrintIsenable
        {
            get { return _btnPrintIsenable; }
            set { SetProperty(ref _btnPrintIsenable, value); }
        }


        private int _MNum;
        /// <summary>
        /// 未打印数量
        /// </summary>
        public int MNum
        {
            get { return _MNum; }
            set { SetProperty(ref _MNum, value); }
        }


        private int? _printNum;
        /// <summary>
        /// 主打印数量
        /// </summary>
        public int? PrintNum
        {
            get { return _printNum; }
            set { SetProperty(ref _printNum, value); }
        }

        private int _SPrintNum=1;
        /// <summary>
        /// 辅料打印套数
        /// </summary>
        public int SprintNum
        {
            get { return _SPrintNum; }
            set { SetProperty(ref _SPrintNum, value); }
        }



        private int? _serialStartNum;
        /// <summary>
        /// 起始流水码
        /// </summary>
        public int? SerialStartNum
        {
            get { return _serialStartNum; }
            set { SetProperty(ref _serialStartNum, value); }
        }
        private int _year=DateTime.Now.Year;
        /// <summary>
        /// 
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }
      


        #endregion
        #region Method
        private void Refresh()
        {
            // 项目/计划  编号集合
            var planCodes = AppDbContext.Db.Queryable<po_info>().Where(x => x.工单状态 == "缺料"||x.工单状态=="上线中").ToList();
            PlanCodes = new ObservableCollection<po_info>(planCodes);
          
        }

        Dictionary<int, string> Mmaterial = new Dictionary<int, string>();
        Dictionary<int, string> Smaterial = new Dictionary<int, string>();
        private void Mmte()
        {
            Mmaterial.Add(11, "ST01");
            Mmaterial.Add(21, "ST02");
            Mmaterial.Add(31, "ST03");
            Mmaterial.Add(41, "ST04");
            Mmaterial.Add(51, "ST05");
            Mmaterial.Add(61, "ST06");
            Mmaterial.Add(71, "ST07");
            Mmaterial.Add(81, "ST08");
            Mmaterial.Add(91, "ST09");
            Mmaterial.Add(101, "ST10");
            Mmaterial.Add(111, "ST11");
            Mmaterial.Add(121, "ST12");

            Smaterial.Add(12, "ST01");
            Smaterial.Add(22, "ST02");
            Smaterial.Add(32, "ST03");
            Smaterial.Add(42, "ST04");
            Smaterial.Add(52, "ST05");
            Smaterial.Add(62, "ST06");
            Smaterial.Add(72, "ST07");
            Smaterial.Add(82, "ST08");
            Smaterial.Add(92, "ST09");
            Smaterial.Add(102, "ST10");
            Smaterial.Add(112, "ST11");
            Smaterial.Add(122, "ST12");
        }
        /// <summary>
        /// 流水号随机号码
        /// </summary>
        /// <returns></returns>
        private  Random random = new Random();
        private  string method2(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// 加载打码信息
        /// </summary>
        private void LoadPrintInfo()
        {
            var printnode = AppDbContext.Db.Queryable<DataTraceability>().Where(x => x.work_order == PlanInfo.工单号).ToList();

            MPrintNodes = new ObservableCollection<DataTraceability>(printnode.Where(x=>x.serial_num.Substring(0,1)=="M").ToList());
            MNum = MPrintNodes.Where(x => x.IsCode == false).Count();
            SPrintNodes = new ObservableCollection<DataTraceability>(printnode.Where(x => x.serial_num.Substring(0,1) == "S").ToList());
            if (MNum > 0)
            {
                BtnPrintIsenable = true;
            }
            else BtnPrintIsenable = false;

        }

        #endregion
        #region Command
        private DelegateCommand<object> _SelectedPlanCodeCommand;
        /// <summary>
        /// 选择计划编号，项目号
        /// </summary>
        public DelegateCommand<object> SelectedPlanCodeCommand => _SelectedPlanCodeCommand ?? (_SelectedPlanCodeCommand = new DelegateCommand<object>(SelectedPlanCode));
        private void SelectedPlanCode(object parameter)
        {
            if (parameter == null) return;
            PlanInfo = parameter as po_info;
            LoadPrintInfo();
        }

        private DelegateCommand _LoadInfoCommand;
        /// <summary>
        /// 加载工单信息，生成流水号
        /// </summary>
        public DelegateCommand LoadInfoCommand => _LoadInfoCommand ?? (_LoadInfoCommand = new DelegateCommand(() =>
        {
            try
            {
                if (SerialStartNum == null)
                {
                    MessageBox.Show("请填写当前工单所使用的标牌流水码的起始值");
                }
                else
                {
                    if (PlanInfo != null)
                    {
                        //工位代码
                        List<int> stationcode = new List<int>();
                        if (string.IsNullOrEmpty(PlanInfo.流转路线))
                        {
                            MessageBox.Show("当前工单对应的产品未配置流转路线");
                        }
                        else
                        {
                            List<string> strings = new List<string>(PlanInfo.流转路线.Split("→"));
                            foreach (string str in strings)
                            {
                                stationcode.Add(Mmaterial.Where(x => x.Value == str).Select(x => x.Key).Single());
                            }
                            //流水码信息生成
                            string finalString = method2(5);
                            if (AppDbContext.Db.Queryable<DataTraceability>().Where(x => x.work_order == PlanInfo.工单号 && x.serial_num.Substring(1, 5) != finalString).Count() < 1)
                            {

                                //主料流水码生成
                                for (int i = 0; i < PlanInfo.工单数量; i++)
                                {
                                    DataTraceability dataTraceability = new DataTraceability();
                                    dataTraceability.serial_num = $"M{finalString}{DateTime.Now.Year}{string.Format("{0:D3}", i+SerialStartNum)}";
                                    dataTraceability.TagSerialnum = $"{PlanInfo.产成品名称}{DateTime.Now.Year}{string.Format("{0:D3}", i + SerialStartNum)}";
                                    dataTraceability.work_order = PlanInfo.工单号;
                                    dataTraceability.station = $"{string.Join(",", stationcode.ToArray())},141";
                                    dataTraceability.procode = PlanInfo.图号;
                                    dataTraceability.proName = PlanInfo.产成品名称;
                                    dataTraceability.IsCode = false;
                                    AppDbContext.Db.Insertable(dataTraceability).ExecuteCommandAsync();
                                }
                                var res = AppDbContext.Db.Queryable<Io_prc_product>().Where(x => x.Pro_Detail.proCode == PlanInfo.图号).ToList();
                                if (res.Count() > 0)
                                {
                                    int count = 0;
                                    foreach (var item in res)
                                    {
                                        DataTraceability dataTraceability = new DataTraceability();
                                        dataTraceability.serial_num = $"S{finalString}{DateTime.Now.Year}{string.Format("{0:D3}", count += 1)}";
                                        dataTraceability.work_order = PlanInfo.工单号;
                                        dataTraceability.station = $"{(int)item.Station}2,141";
                                        dataTraceability.procode = PlanInfo.图号;
                                        dataTraceability.proName = PlanInfo.产成品名称;
                                        dataTraceability.IsCode = false;
                                        AppDbContext.Db.Insertable(dataTraceability).ExecuteCommandAsync();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("此产品未配置工序");
                                }

                            }
                            else
                            {
                                MessageBox.Show("此工单的流水号已经存在，禁止重复生成");
                            }
                            LoadPrintInfo();
                            //加载打码信息后，认为物料已经齐套，将工单状态变更为上线中，否则为缺料
                            PlanInfo.工单状态 = "上线中";
                            AppDbContext.Db.Updateable(PlanInfo).ExecuteCommandAsync();
                        }
                    }


                    else
                    {
                        //选择工单信息

                    }
                }

              
                //删除过期数据  
                AppDbContext.Db.Deleteable<DeviceStopDate>().Where(x => x.StopTime < DateTime.Now.AddDays(-3)).ExecuteCommandAsync();
                AppDbContext.Db.Deleteable<DataTraceability>().Where(x => x.CreatTime < DateTime.Now.AddMonths(-2)).ExecuteCommandAsync();
                AppDbContext.Db.Deleteable<dt_Trace_Track>().Where(x => x.IN_Station < DateTime.Now.AddMonths(-6)).ExecuteCommandAsync();
                AppDbContext.Db.Deleteable<po_info>().Where(x => x.计划完工日期 < DateTime.Now.AddMonths(-6)).ExecuteCommandAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }));

        private DelegateCommand<object> _PrintLableCommand;
        /// <summary>
        /// 打印标签
        /// </summary>
        public DelegateCommand<object> PrintLableCommand => _PrintLableCommand ?? (_PrintLableCommand = new DelegateCommand<object>(PrintLable));
        private void PrintLable(object parameter)
        {
            Task.Run(() =>
            {
                string finalString = parameter as string;
                try
                {
                    BtnPrintIsenable = false;
                    if (finalString == "主")
                    {
                        //获取未打印的流水码
                        var codeinfo = AppDbContext.Db.Queryable<DataTraceability>().Where(x => x.IsCode == false && x.work_order == PlanInfo.工单号 && x.serial_num.StartsWith("M")).ToList();
                        if (codeinfo.Count > 0)
                        {
                            if (PrintNum != null)
                            {
                                var res = codeinfo.Take((int)PrintNum).ToList();

                                foreach (var item in res)
                                {
                                    PrintData printData = new PrintData()
                                    {
                                        MaterialtType = 1,
                                        MaterialCode = PlanInfo.流转路线.Split("→")[0],
                                        MaterialName = "目标工位",
                                        BatchNum = item.work_order,
                                        ProCode = item.serial_num.Substring(item.serial_num.Length-7),
                                        ProName = item.proName,
                                        SerialNum = item.serial_num,
                                        FlagFixed = $"WV010-02A-",
                                    };
                                    var result = printServiceClient.PrinterHelperAsync(printData);
                                    if (result.Result == "success")
                                    {
                                        item.IsCode = true;
                                        AppDbContext.Db.Updateable(item).ExecuteCommand();
                                    }
                                    else
                                    {
                                        MessageBox.Show("检查标签机是否连接网络或者是否开机,并查看服务是否开启");
                                    }

                                }
                                MessageBox.Show("打印完成");
                              
                                LoadPrintInfo();
                            }
                            else
                            {
                                MessageBox.Show("请输入要打码的数量");
                            }




                        }
                        else
                        {
                            MessageBox.Show("此工单的条码已打印完毕，如有条码损坏，请进行补打");
                        }
                    }


                }
                catch (Exception ex)
                {

                    Log.Error($"打印条码失败，原因:{ex.Message}");
                }
                BtnPrintIsenable = true;
            });
        
         
        }
        private DelegateCommand _PrintLableSCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand PrintLableSCommand => _PrintLableSCommand ?? (_PrintLableSCommand = new DelegateCommand(() =>
        {
            Task.Run(() =>
            {
                var Scodeinfo = SPrintNodes.Where(x => x.IsShipped == true).ToList();
                if (Scodeinfo.Count > 0)
                {
                    if (SprintNum > 0)
                    {
                        for (int i = 0; i < SprintNum; i++)
                        {
                            foreach (var item in Scodeinfo)
                            {
                                string value;
                                string st = item.station.Split(",")[0];
                                Smaterial.TryGetValue(Convert.ToInt32(st), out value);
                                PrintData printData = new PrintData()
                                {
                                    MaterialtType = 2,
                                    MaterialCode = value,
                                    MaterialName = "目标工位",
                                    BatchNum = item.work_order,
                                    ProCode = item.procode,
                                    ProName = item.proName,
                                    SerialNum = item.serial_num,
                                    FlagFixed = $"WV010-02A-",
                                };
                                var result = printServiceClient.PrinterHelperAsync(printData);
                                if (result.Result == "success")
                                {
                                    //item.IsCode = true;
                                    //AppDbContext.Db.Updateable(item).ExecuteCommand();
                                }
                                else
                                {
                                    MessageBox.Show("检查标签机是否连接网络或者是否开机,并查看服务是否开启");
                                }

                            }
                        }
                        MessageBox.Show("打印完成");
                    }
                    else
                    {
                        MessageBox.Show("请输入要打印的套数");
                    }



                }
                else { MessageBox.Show("检查是否配置工序"); }
            });
            //var Scodeinfo = AppDbContext.Db.Queryable<DataTraceability>().Where(x => x.work_order == PlanInfo.工单号 && x.serial_num.StartsWith("S")).ToList();
          
        }));


        private DelegateCommand<object> _ReprintCommand;
        /// <summary>
        /// 补印
        /// </summary>
        public DelegateCommand<object> ReprintCommand => _ReprintCommand ?? (_ReprintCommand = new DelegateCommand<object>(ReprintC));
        private void ReprintC(object parameter)
        {
            if(parameter == null)return;
            var item = parameter as DataTraceability;
            try
            {
                PrintData printData = new PrintData()
                {
                    MaterialtType = 1,
                    MaterialCode = PlanInfo.流转路线.Split("→")[0],
                    MaterialName = "目标工位",
                    BatchNum = item.work_order,
                    ProCode = item.procode,
                    ProName = item.proName,
                    SerialNum = item.serial_num,
                    FlagFixed = $"WV010-02A-",
                };
                var result = printServiceClient.PrinterHelperAsync(printData);
                if (result.Result == "success")
                {
                    item.IsCode = true;
                    AppDbContext.Db.Updateable(item).ExecuteCommand();
                }
            }
            catch (Exception ex)
            {

                Log.Error($"补印条码失败，原因:{ex.Message}");
            }
        }



        #endregion

    }
}
