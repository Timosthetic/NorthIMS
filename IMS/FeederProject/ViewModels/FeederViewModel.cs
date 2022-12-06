using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Infrastructure.DealWithFile;
using Infrastructure.Dto;
using Infrastructure.Dto.Login;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Serilog;

namespace FeederProject.ViewModels
{
    public class FeederViewModel : BindableBase
    {
        private readonly IBaseService _baseService;
        public FeederViewModel(IContainerExtension container)
        {
            Mmte();
            _baseService = container.Resolve<IBaseService>();
            Refresh();

        }
        #region Files

        private ObservableCollection<po_info> _po_info;
        /// <summary>
        /// 工单信息
        /// </summary>
        public ObservableCollection<po_info> Po_Infos
        {
            get { return _po_info; }
            set { SetProperty(ref _po_info, value); }
        }


        private bool _IsFocusable;
        /// <summary>
        /// 
        /// </summary>
        public bool IsFocusable
        {
            get { return _IsFocusable; }
            set { SetProperty(ref _IsFocusable, value); }
        }

        private ObservableCollection<Io_Vehicles_Bing> _vehiclesBing;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Io_Vehicles_Bing> Vehicles_Bings
        {
            get { return _vehiclesBing; }
            set { SetProperty(ref _vehiclesBing, value); }
        }


        private ObservableCollection<StatonNeed> _needStation;
        /// <summary>
        /// 缺料工位
        /// </summary>
        public ObservableCollection<StatonNeed> NeedStation
        {
            get { return _needStation; }
            set { SetProperty(ref _needStation, value); }
        }


        #endregion

        #region Command






        #endregion

        #region Method

        Dictionary<string, int> Mmaterial = new Dictionary<string, int>();
        private void Mmte()
        {
            Mmaterial.Add( "ST01",11);
            Mmaterial.Add( "ST02",21);
            Mmaterial.Add( "ST03",31);
            Mmaterial.Add( "ST04",41);
            Mmaterial.Add( "ST05",51);
            Mmaterial.Add( "ST06",61);
            Mmaterial.Add( "ST07",71);
            Mmaterial.Add( "ST08",81);
            Mmaterial.Add( "ST09",91);
            Mmaterial.Add( "ST10",101);
            Mmaterial.Add( "ST11",111);
            Mmaterial.Add( "ST12",121);
        }
        /// <summary>
        /// 工单首工位集合
        /// </summary>
        private List<string> fistStation;
        /// <summary>
        /// 
        /// </summary>
        private  List<float> CTS;

        

        /// <summary>
        /// 实时刷新工单信息
        /// </summary>
        private void Refresh()
        {

            Task.Run(async () =>
            {
                try
                {
                    while (true)
                    {
                        var res = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => !string.IsNullOrEmpty(x.serial_num) && !string.IsNullOrEmpty(x.pro_code)).ToList();
                        Vehicles_Bings = new ObservableCollection<Io_Vehicles_Bing>(res);
                        var refresh = AppDbContext.Db.Queryable<po_info>().Where(x => x.工单状态 == "上线中").ToList();
                        Po_Infos = new ObservableCollection<po_info>(refresh);

                        fistStation=new List<string>();
                        CTS = new List<float>();
                        if (refresh.Count > 0)
                        {
                            



                            foreach (var item in refresh)
                            {

                                #region 智能入库
                              var Ct=  AppDbContext.Db.Queryable<Io_prc_product>().Where(x => x.Pro_Detail.proCode == item.图号).Includes(x => x.Pro_Detail).First();
                                CTS.Add(Ct.CT);
                                #endregion



                                fistStation.Add(item.流转路线.Split("→")[0]);
                            }
                        }

                        if(fistStation.Count > 0)
                        {
                            NeedStation = new ObservableCollection<StatonNeed>();
                            foreach (var item in fistStation)
                            {
                                int value;
                               Mmaterial.TryGetValue(item, out value);
                             var count=  AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x=>x.current_st.Equals(value.ToString())).Count();
                                if (count < 1)
                                {
                                    NeedStation.Add(new StatonNeed { stid=value.ToString(),stName=item });
                                }
                            }
                        }



                        await Task.Delay(3000);




                    }
                }
                catch (Exception ex)
                {

                    Log.Error($"刷新工单数据失败，原因：{ex.Message}");
                }
            });

        }
        #endregion
    }

    public class StatonNeed
    {
        public string stid { get; set; }
        public string stName { get; set; }
    }
}
