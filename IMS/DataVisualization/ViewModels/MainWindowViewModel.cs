using DataVisualization.Models;
using Infrastructure.Bogus;
using Infrastructure.Dto;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DataVisualization.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region MyRegion

        private string _lineName;
        /// <summary>
        /// 线体名称
        /// </summary>
        public string LineName
        {
            get { return _lineName; }
            set { SetProperty(ref _lineName, value); }
        }

        private ObservableCollection<StaffLogin> _staffLogin;
        /// <summary>
        /// 工位状态
        /// </summary>
        public ObservableCollection<StaffLogin> StaffLogins
        {
            get { return _staffLogin; }
            set { SetProperty(ref _staffLogin, value); }
        }

        private ObservableCollection<kanBan_WorkingHours> _kanbanWorkingHours;
        /// <summary>
        /// 工时统计
        /// </summary>
        public ObservableCollection<kanBan_WorkingHours> KanbanWorkingHours
        {
            get { return _kanbanWorkingHours; }
            set { SetProperty(ref _kanbanWorkingHours, value); }
        }


        private ObservableCollection<po_info> _workorder;
        /// <summary>
        /// 工单数据
        /// </summary>
        public ObservableCollection<po_info> WorkOrders
        {
            get { return _workorder; }
            set { SetProperty(ref _workorder, value); }
        }

        private string _productName;
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }


        private List<kanBan_WorkingHours> bufferWork;
        private List<StaffLogin> bufferStation;

        private List<po_info> bufferWorkorder;

        #endregion

        public MainWindowViewModel()
        {
            LineName = $"{ConfigurationHelper.ReadSetting("Line")}车间单体装配柔性生产线";
          
                bufferWork = SqlDbContext.Db.Queryable<kanBan_WorkingHours>().ToList();
                KanbanWorkingHours = new ObservableCollection<kanBan_WorkingHours>(bufferWork);
                bufferStation = SqlDbContext.Db.Queryable<StaffLogin>().ToList();
                StaffLogins = new ObservableCollection<StaffLogin>(bufferStation);
                bufferWorkorder = SqlDbContext.Db.Queryable<po_info>().ToList();
                WorkOrders = new ObservableCollection<po_info>(bufferWorkorder);
          




            PoBogus = new ObservableCollection<po_info_bogus>();
            PoBogus.Add(new po_info_bogus() {项目号="20220803", 产成品名称="机箱001",工单号="20220706",工单数量=79,工单状态= "已完工", 图号="AZ002.JH.001",计划完工日期=DateTime.Now,实际完工日期=DateTime.Now,工位利用率= "4/12",合格率= "100%" });
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220804", 产成品名称 = "机箱002", 工单号 = "20220706", 工单数量 = 34, 工单状态 = "已完工", 图号 = "AZ001.JH.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "8/12", 合格率 = "100%"});
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220805", 产成品名称 = "机箱003", 工单号 = "20220705", 工单数量 = 342, 工单状态 = "已上线", 图号 = "AZ001.FH.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "6/12", 合格率 = "100%" });
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220803", 产成品名称 = "机箱004", 工单号 = "20220703", 工单数量 = 123, 工单状态 = "已上线", 图号 = "AZ003.GH.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "6/12", 合格率 = "100%" });
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220809", 产成品名称 = "机箱005", 工单号 = "20220704", 工单数量 = 43, 工单状态 = "待上线", 图号 = "AZ004.HH.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "0/12", 合格率 = "100%" });
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220801", 产成品名称 = "机箱006", 工单号 = "20220506", 工单数量 = 78, 工单状态 = "待上线", 图号 = "AZ006.BH.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "0/12", 合格率 = "100%" });
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220802", 产成品名称 = "机箱007", 工单号 = "20220806", 工单数量 = 372, 工单状态 = "待上线", 图号 = "AZ002.SD.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "0/12", 合格率 = "100%" });
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220803", 产成品名称 = "机箱008", 工单号 = "20220206", 工单数量 = 89, 工单状态 = "待上线", 图号 = "AZ001.SB.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "0/12", 合格率 = "100%" });
            PoBogus.Add(new po_info_bogus() { 项目号 = "20220807", 产成品名称 = "机箱009", 工单号 = "20220106", 工单数量 = 100, 工单状态 = "待上线", 图号 = "AZ003.HH.001", 计划完工日期 = DateTime.Now, 实际完工日期 = DateTime.Now, 工位利用率 = "0/12", 合格率 = "100%" });
            Task.Run(async () =>
            {
                while (true)
                {
                    Time = DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm:ss");


                    await Task.Delay(1000);
                }
            });


          


            Task.Run(async () =>
            {

                while (true)
                {
                    try
                    {


                        //工单信息
                        var workerorder =  SqlDbContext.Db.Queryable<po_info>().ToList(); 
                        //var wokodif = workerorder.Where(x => bufferWorkorder.Any(x2 => x.Id == x2.Id && x.工单状态 != x2.工单状态&&x.已完工数量!=x2.已完工数量)).Count();
                        //if(wokodif > 0)
                        //{
                        //    bufferWorkorder = workerorder;
                            WorkOrders=new ObservableCollection<po_info>(workerorder.TakeLast(9));
                        //}
                        //工位状态
                        bufferStation = SqlDbContext.Db.Queryable<StaffLogin>().ToList();
                        StaffLogins = new ObservableCollection<StaffLogin>(bufferStation);
                       
                       
                        //工时统计
                        var kanbandata = await SqlDbContext.Db.Queryable<kanBan_WorkingHours>().ToListAsync();
                        var dif = kanbandata.Where(x => bufferWork.Any(x2 => x.ID == x2.ID && x.Processing_Hours != x2.Processing_Hours)).Count();
                        if (dif > 0)
                        {
                            bufferWork = kanbandata;
                            KanbanWorkingHours = new ObservableCollection<kanBan_WorkingHours>(kanbandata);
                        }


                      
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                 
                   
                



                

                    await Task.Delay(1000);

                }

            });



            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var pos = await SqlDbContext.Db.Queryable<po_info>().Where(x => x.工单状态 == "上线中").ToListAsync();
                        if (pos.Count > 0)
                        {
                            foreach (var item in pos)
                            {
                                var count = SqlDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.workorder == item.工单号&&x.wms_code==0&&x.serial_num.Substring(0, 1) == "M").Count();
                                if (count > 0)
                                {
                                    item.线上数量 = count;
                                  
                                }
                                else
                                {
                                    item.线上数量 = 0;
                                }
                                await SqlDbContext.Db.Updateable(item).ExecuteCommandAsync();
                            }
                        }

                     

                        var pie = await SqlDbContext.Db.Queryable<po_info>().Where(x => x.工单状态 == "上线中").ToListAsync();

                        if (pie.Count > 0)
                        {
                            foreach (var item in pie)
                            {
                                ProductName = item.产成品名称;
                                Tax = new ObservableCollection<DoughnutChartModel>();
                                Tax.Add(new DoughnutChartModel() { Category = "完工数量", Percentage = item.已完工数量 });
                                Tax.Add(new DoughnutChartModel() { Category = "已上线数量", Percentage = item.线上数量 });
                                Tax.Add(new DoughnutChartModel() { Category = "待上线数量", Percentage = item.工单数量 - item.已完工数量 - item.线上数量 });
                                await Task.Delay(20000);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                    await Task.Delay(1000);
                }
            });



        }

        #region Files
        private ObservableCollection<po_info_bogus> _poBogus;
        /// <summary>
        /// 虚假数据
        /// </summary>
        public ObservableCollection<po_info_bogus> PoBogus
        {
            get { return _poBogus; }
            set { SetProperty(ref _poBogus, value); }
        }

        private ObservableCollection<StackingColumnChartModel> _medalDetails;
        public ObservableCollection<StackingColumnChartModel> MedalDetails
        {
            get { return _medalDetails; }
            set { SetProperty(ref _medalDetails, value); }
        }
        private double _startAngle;
        /// <summary>
        /// 
        /// </summary>
        public double StartAngle
        {
            get { return _startAngle; }
            set { SetProperty(ref _startAngle, value); }
        }
        private double _endAngle;
        /// <summary>
        /// 
        /// </summary>
        public double EndAngle
        {
            get { return _endAngle; }
            set { SetProperty(ref _endAngle, value); }
        }
        private string _selectedItemName;
        /// <summary>
        /// 
        /// </summary>
        public string SelectedItemName
        {
            get { return _selectedItemName; }
            set { SetProperty(ref _selectedItemName, value); }
        }
        private double _selectedItemsPercentage;
        /// <summary>
        /// 
        /// </summary>
        public double SelectedItemsPercentage
        {
            get { return _selectedItemsPercentage; }
            set { SetProperty(ref _selectedItemsPercentage, value); }
        }
        private int _selectedIndex;
        /// <summary>
        /// 
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    SetProperty(ref _selectedIndex, value);
                    if (Tax != null && _selectedIndex > -1 && _selectedIndex < Tax.Count)
                    {
                        SelectedItemName = Tax[_selectedIndex].Category;
                        SelectedItemsPercentage = Tax[_selectedIndex].Percentage;
                    }
                }

            }
        }
        private ObservableCollection<DoughnutChartModel> _tax;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<DoughnutChartModel> Tax
        {
            get { return _tax; }
            set { SetProperty(ref _tax, value); }
        }

        private string _time;
        /// <summary>
        /// 
        /// </summary>
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }


        #endregion
        #region Method
        /// <summary>
        /// 获取工单信息
        /// </summary>
        private void GetPo_Info()
        {
            SqlDbContext.Db.Queryable<po_info>().ToList();

        }
        #endregion

    }
}
