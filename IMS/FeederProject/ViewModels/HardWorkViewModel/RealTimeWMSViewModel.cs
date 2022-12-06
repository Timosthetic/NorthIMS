using FeederProject.Models;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using Prism.Commands;
using Prism.Mvvm;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FeederProject.ViewModels.HardWorkViewModel
{
    public  class RealTimeWMSViewModel : BindableBase
    {
       
        public RealTimeWMSViewModel()
        {
          
            GetWMSValue();

           
            Task.Run(() => RealTimeInfo());
           
        }

        private async void RealTimeInfo()
        {
            while (true)
            {
                Refresh();
                await Task.Delay(2000);
            }
        }

        List<RealTimeWMS> realTimeWMs;
      private void GetWMSValue()
        {

             realTimeWMs = new List<RealTimeWMS>();
            realTimeWMs.Add(new RealTimeWMS() {Id=0, wms_code = 301 });
            realTimeWMs.Add(new RealTimeWMS() { Id =1 , wms_code = 302 });
            realTimeWMs.Add(new RealTimeWMS() { Id =2 , wms_code = 303 });
            realTimeWMs.Add(new RealTimeWMS() {Id = 3, wms_code = 310 });
            realTimeWMs.Add(new RealTimeWMS() { Id =4 , wms_code = 311 });
            realTimeWMs.Add(new RealTimeWMS() { Id =5 , wms_code = 312 });
            realTimeWMs.Add(new RealTimeWMS() { Id =6 , wms_code = 313 });
            realTimeWMs.Add(new RealTimeWMS() { Id =7 , wms_code = 314 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 8, wms_code = 315 });
            realTimeWMs.Add(new RealTimeWMS() { Id =9 , wms_code = 304 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 10, wms_code = 305 });
            realTimeWMs.Add(new RealTimeWMS() { Id =11 , wms_code = 306 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 12, wms_code = null, BackGround = "Transparent" });
            realTimeWMs.Add(new RealTimeWMS() { Id = 13, wms_code = null, BackGround = "Transparent" });
            realTimeWMs.Add(new RealTimeWMS() { Id =14 , wms_code = null, BackGround = "Transparent" });
            realTimeWMs.Add(new RealTimeWMS() { Id = 15, wms_code = 316 });
            realTimeWMs.Add(new RealTimeWMS() { Id =16 , wms_code = 317 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 17, wms_code = 318 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 18, wms_code = 307 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 19, wms_code = 308 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 20, wms_code = 309 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 21, wms_code = null, BackGround = "Transparent" });
            realTimeWMs.Add(new RealTimeWMS() { Id =22 , wms_code = null, BackGround = "Transparent" });
            realTimeWMs.Add(new RealTimeWMS() { Id = 23, wms_code = null, BackGround = "Transparent" });
            realTimeWMs.Add(new RealTimeWMS() { Id =24 , wms_code = 319 });
            realTimeWMs.Add(new RealTimeWMS() { Id =25 , wms_code = 320 });
            realTimeWMs.Add(new RealTimeWMS() { Id = 26, wms_code = 321 });
            WMSS = new ObservableCollection<RealTimeWMS>(realTimeWMs);

        }
        private void Refresh()
        {
            try
            {
                GetWMSValue();
                var wms = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.wms_code != 0).ToList();
                if (wms.Count > 0)
                {
                    foreach (var item in wms)
                    {
                        
                        var res = realTimeWMs.Where(x => x.wms_code == item.wms_code).FirstOrDefault();
                        realTimeWMs.Remove(res);
                        res.wms_code = item.wms_code;
                        res.serial_num = item.serial_num;
                        res.BackGround = "Green";
                        res.Station =$"目标工位代号:{item.circulation_st.Split(",")[0]}" ;
                        res.ProName= item.pro_code;
                        realTimeWMs.Insert(res.Id, res);
                    }
                    WMSS = new ObservableCollection<RealTimeWMS>(realTimeWMs);
                }
            }
            catch (Exception ex)
            {

                Log.Error($"更新立库信息失败,原因:{ex.Message}");
            }
        
        }


        private DelegateCommand _refreshCommand;
        /// <summary>
        /// 刷新
        /// </summary>
        public DelegateCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new DelegateCommand(() =>
        {
            

            Refresh();
        }));



        private ObservableCollection<RealTimeWMS> _wms; 
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<RealTimeWMS> WMSS
        {
            get { return _wms; }
            set { SetProperty(ref _wms, value); }
        }

        #region Command
        private DelegateCommand<object> _SelectedWMSCODECommand;
       

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<object> SelectedWMSCODECommand => _SelectedWMSCODECommand ?? (_SelectedWMSCODECommand = new DelegateCommand<object>(SelectedWMSCODE));
        private void SelectedWMSCODE(object parameter)
        {
            if(parameter == null) return;
            var res=parameter as RealTimeWMS;
            var wmcode=(int)res.wms_code;
            if (MessageBox.Show($"是否将此库位{wmcode}托盘取出到下线处", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                bool isexiste = AppDbContext.Db.Queryable<WMS_TaskQueues>().Where(x => x.wms_code == wmcode).Any();
                if (!isexiste)
                {
                    WMS_TaskQueues wMS_TaskQueues = new WMS_TaskQueues()
                    {
                        st_num = "300",
                        wms_code = wmcode,
                        task_status = 0,
                        tag_order = "Down",
                        isexists_MS = 3,

                    };
                    AppDbContext.Db.Insertable(wMS_TaskQueues).ExecuteCommand();
                    var Down = AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.wms_code == wmcode).First();
                    if (Down != null)
                    {
                        Down.circulation_st = "300";
                        AppDbContext.Db.Updateable(Down).ExecuteCommandAsync();
                    }
                }


            }



        }

        #endregion
    }


   public class Test
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
