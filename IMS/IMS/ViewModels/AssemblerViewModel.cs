using IMS.Model;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Infrastructure.Dto;
using Infrastructure.Helper;
using Prism.Events;
using Infrastructure.Event;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Windows;
using System.Net;
using Infrastructure.Dto.NewDto;
using Serilog;
using PrintServer;
using System.IO;
using Infrastructure.Model;

namespace IMS.ViewModels
{
    /// <summary>
    /// 装配员
    /// </summary>
    public class AssemblerViewModel:BindableBase
    {
        PrintServiceClient printServiceClient;
        public AssemblerViewModel()
        {

            Mmte();



            printServiceClient = new PrintServiceClient();

            try
            {
                if (!string.IsNullOrEmpty(GetStationName()))
                {
                    Station = (EnumStation)Enum.Parse(typeof(EnumStation), GetStationName());
                }
            }
            catch (Exception ex)
            {

                Log.Error($"获取硬件工位信息失败，原因：{ex.Message}");
            }


            StaffNum = ConfigurationHelper.ReadSetting("UserNum");
            StaffName = ConfigurationHelper.ReadSetting("UserName");

            Task.Run(() => RealTimeInfo());
        }
       
        private async void RealTimeInfo()
        {
            while (true)
            {
                try
                {
                    St = (int)Station;
                   var po_Infos= AppDbContext.Db.Queryable<po_info>().Where(x => x.工单状态 == "上线中").ToList();
                    if(po_Infos.Count() >0)
                    {
                        for (int i = 0; i < po_Infos.Count; i++)
                        {
                           

                            var res = AppDbContext.Db.Queryable<Io_prc_product>()

                            .Where(x => x.Pro_Detail.proCode == po_Infos[i].图号 && x.Station.Equals(Station))
                            .Includes(x => x.Pro_Detail)
                            .Includes(s => s.StanardList).First();
                            if (res != null)
                            {
                                WorkerOrder = po_Infos[i].工单号;
                                Product = po_Infos[i].产成品名称;
                                Product = res.Pro_Detail.proName;
                                Process = res.NodeName;
                                BOMinfo = new ObservableCollection<Io_prc_standard>(res.StanardList);
                         var stafflogion=   await    AppDbContext.Db.Queryable<StaffLogin>().Where(x => x.Station == GetStationName()).SingleAsync();


                                stafflogion.StaffNum = StaffNum;
                                stafflogion.StaffName = StaffName;


                                stafflogion.ProductName = po_Infos[i].产成品名称;
                                   stafflogion.ProcessName = res.NodeName;
                                if (WorkerOrder == "")
                                {
                                    stafflogion.ProcessStatus = false;
                                }
                                else
                                {
                                    stafflogion.ProcessStatus = true;
                                }
                                  

                                   stafflogion.IsLogin = true;
                               
                                await AppDbContext.Db.Updateable(stafflogion).ExecuteCommandAsync();

                                if (!string.IsNullOrEmpty(res.Esop))
                                {
                                    Stream stream = await printServiceClient.DownloadStreamAsync(res.Esop);


                                   
                                    if (!Directory.Exists(@"D:\SOP"))     // 返回bool类型，存在返回true，不存在返回false
                                    {
                                        Directory.CreateDirectory(@"D:\SOP");      //不存在则创建路径
                                    }
                                    string filePath = System.IO.Path.Combine(@"D:\SOP", "SOPFile.pdf");
                                    FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                                    byte[] bytes = new byte[1024];
                                    int num;
                                    int count0 = 0;
                                    do
                                    {
                                        num = stream.Read(bytes, 0, bytes.Length);
                                        fs.Write(bytes, 0, num);
                                        count0 += num;
                                    } while (num > 0);
                                    fs.Close();
                                    stream.Close();

                                }




                            }

                        }
                      
                    }
                    else
                    {

                    }
                

                    await Task.Delay(3000);
                }
                catch (Exception ex)
                {
                    Log.Error($"获取SOP异常:{ex.Message}");
                }
            }

        }


        #region Method

        private string GetStationName()
        {
            //通过设备名称区分工位信息
            string str = Dns.GetHostName();
            if (str.Contains("ST"))
            {
               return str;
            }
            else
            {
                return "";
            }
           
        }
        #endregion

        #region Files


        private Stream _SOPFile;
        /// <summary>
        /// 
        /// </summary>
        public Stream SOPFile
        {
            get { return _SOPFile; }
            set { SetProperty(ref _SOPFile, value); }
        }


        private ObservableCollection<Io_prc_standard> _bominfo;
        /// <summary>
        /// BOM 清单
        /// </summary>
        public ObservableCollection<Io_prc_standard> BOMinfo
        {
            get { return _bominfo; }
            set { SetProperty(ref _bominfo, value); }
        }
        private int St;

        private EnumStation _station;
        /// <summary>
        /// 工位标识
        /// </summary>
        public EnumStation Station
        {
            get { return _station; }
            set { SetProperty(ref _station, value); }
        }
        private string _staffNum;
        /// <summary>
        /// 员工号
        /// </summary>
        public string StaffNum
        {
            get { return _staffNum; }
            set { SetProperty(ref _staffNum, value); }
        }
        private string _staffName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName
        {
            get { return _staffName; }
            set { SetProperty(ref _staffName, value); }
        }
        private string _Barcode;
        /// <summary>
        /// 标签信息
        /// </summary>
        public string Barcode
        {
            get { return _Barcode; }
            set { SetProperty(ref _Barcode, value); }
        }
        private string _wokerOrder;
        /// <summary>
        /// 工单
        /// </summary>
        public string WorkerOrder
        {
            get { return _wokerOrder; }
            set { SetProperty(ref _wokerOrder, value); }
        }
        private string _product;
        /// <summary>
        /// 产品
        /// </summary>
        public string Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }
        private string _process;
        /// <summary>
        /// 工序
        /// </summary>
        public string Process
        {
            get { return _process; }
            set { SetProperty(ref _process, value); }
        }


        private ObservableCollection<material_outqty_record> _DisboxList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<material_outqty_record> DisboxList
        {
            get { return _DisboxList; }
            set { SetProperty(ref _DisboxList, value); }
        }


        private ObservableCollection<product_process_order> _processList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<product_process_order> ProcessList
        {
            get { return _processList; }
            set { SetProperty(ref _processList, value); }
        }
        private ObservableCollection<material_outqty_record> _boxInfoList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<material_outqty_record> BoxInfoList
        {
            get { return _boxInfoList; }
            set { SetProperty(ref _boxInfoList, value); }
        }
        private string _result;
        /// <summary>
        /// 
        /// </summary>
        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        #endregion




        #region Command
        private DelegateCommand _InquryCommand;
        /// <summary>
        /// 跟据扫码信息进行查询
        /// </summary>
        public DelegateCommand InquryCommand => _InquryCommand ?? (_InquryCommand = new DelegateCommand(() =>
        {
            try
            {
                if (!string.IsNullOrEmpty(Barcode))
                {
                    Result = "OK";
                    Task.Run(() =>
                    {
                        Thread.Sleep(3000);
                        Barcode = "";
                    });
                   
                }
                   
                    //}
                    //else
                    //{
                    //    MessageBox.Show("不合法标签，未找到对应标签信息");
                    //}
                    //Barcode = "";
              
            }
            catch (Exception ex)
            {

            }
        }));

        private DelegateCommand _TargetCommand;
        /// <summary>
        /// 不良品标记
        /// </summary>
        public DelegateCommand TargetCommand => _TargetCommand ?? (_TargetCommand = new DelegateCommand(() =>
        {

            int st;
            Mmaterial.TryGetValue(GetStationName(), out st);
           

            if (MessageBox.Show($"是否将当前产品标记为不良品", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
              
               var res= AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.current_st == st.ToString()).First();
                if(res != null)
                {

                    if(res.ProMark==3)
                    {
                        MessageBox.Show("此托盘已放行出站，禁止标记不良品");
                    }
                    else if(res.ProMark == 1)
                    {
                        res.await_st = $"{st},141";
                        //流转工位变更为NG，代表此产品未NG品
                        res.ProMark = 2;
                        AppDbContext.Db.Updateable(res).ExecuteCommandAsync();
                        MessageBox.Show("不良品标记成功");
                    }
                    else
                    {
                        MessageBox.Show("此产品已被标记为不良品，无需重复标记");
                    }
                  
                }
                else
                {
                    MessageBox.Show("当前工位无产品可以标记");
                }
            }
            else
            {

            }
        }));

        Dictionary<string, int> Mmaterial = new Dictionary<string, int>();
        private void Mmte()
        {
            Mmaterial.Add("ST01", 11);
            Mmaterial.Add("ST02", 21);
            Mmaterial.Add("ST03", 31);
            Mmaterial.Add("ST04", 41);
            Mmaterial.Add("ST05", 51);
            Mmaterial.Add("ST06", 61);
            Mmaterial.Add("ST07", 71);
            Mmaterial.Add("ST08", 81);
            Mmaterial.Add("ST09", 91);
            Mmaterial.Add("ST10", 101);
            Mmaterial.Add("ST11", 111);
            Mmaterial.Add("ST12", 121);
        }
        #endregion


    }
}
