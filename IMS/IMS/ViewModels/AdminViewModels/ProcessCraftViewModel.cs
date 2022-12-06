using IMS.ViewModels.DialogViewModels;
using Infrastructure.DialogHelper;
using Infrastructure.Dto;
using Infrastructure.Dto.NewDto;
using Infrastructure.Event;
using Infrastructure.Helper;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace IMS.ViewModels.AdminViewModels
{
    public class ProcessCraftViewModel : BindableBase
    {
        IRegionManager _regionManager;
        private readonly IDialogHostService _dialogHostService;
        
        public ProcessCraftViewModel(IRegionManager regionManager, IContainerExtension container, IEventAggregator ea)
        {
            _regionManager = regionManager;
            ea.GetEvent<EventRefresh>().Subscribe(CompRefresh);
            _dialogHostService =container.Resolve<IDialogHostService>();

            Refresh();
          
        }

        private void CompRefresh()
        {
            var procls = AppDbContext.Db.Queryable<Io_pro_CompleteSet>().Where(x => x.Product == ProuductId).ToList();
            Pro_CompleteSets = new ObservableCollection<Io_pro_CompleteSet>(procls);
            Check();



        }
        #region Files
        private bool _isEnable=false;
        /// <summary>
        /// 判断是否有选中工序，如果为选中工序禁止配工艺
        /// </summary>
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }




        private ObservableCollection<string> _product;
        /// <summary>
        /// 产品型号
        /// </summary>
        public ObservableCollection<string> Product

        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }
        private ObservableCollection<Io_prc_product> _prcess;
        /// <summary>
        /// 工序
        /// </summary>
        public ObservableCollection<Io_prc_product> Prcess
        {
            get { return _prcess; }
            set { SetProperty(ref _prcess, value); }
        }

       
       




        private ObservableCollection<Io_pro_CompleteSet> _procls;
        /// <summary>
        /// 此产品类型的齐套
        /// </summary>
        public ObservableCollection<Io_pro_CompleteSet> Pro_CompleteSets
        {
            get { return _procls; }
            set { SetProperty(ref _procls, value); }
        }


        private int _prouductID;
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProuductId
        {
            get { return _prouductID; }
            set { SetProperty(ref _prouductID, value); }
        }









        #endregion
        #region Method
        /// <summary>
        /// 校验工艺配置是否完成
        /// </summary>
        private void Check()
        {
            //查验产品工艺是否配置完成
            var count = AppDbContext.Db.Queryable<Io_pro_CompleteSet>().Where(x => x.Product == io_Prc_Product1.Product && x.mal_lastnum != 0).Count();
            var io_pro_details = AppDbContext.Db.Queryable<Io_pro_details>().Where(x => x.ID == io_Prc_Product1.Product).Single();
            if (count < 1)
            {
              
                io_pro_details.isPrc = true;
              
            }
            else
            {
                io_pro_details.isPrc = false;
            }
            AppDbContext.Db.Updateable(io_pro_details).ExecuteCommand();
        }
        /// <summary>
        /// 打开对应的工艺页面
        /// </summary>
        /// <param name="io_Prc_Product"></param>
        private void OpenTabItem(Io_prc_product io_Prc_Product)
        {
            try
            {
                if(io_Prc_Product != null)
                {
                    var res = AppDbContext.Db.Queryable<Io_prc_product>().Where(x => x.ID == io_Prc_Product.ID).Includes(x => x.StanardList).Single();
                    var parameters = new NavigationParameters();
                    parameters.Add("prcName", res);
                    _regionManager.RequestNavigate("PersonDetailsRegion", "PrcCraftTabView", parameters);
                }
               
            }
            catch (Exception ex)
            {

                Log.Error($"获取工艺失败,原因:{ex.Message}");
            }
           
        }
        private void Refresh()
        {
            try
            {

               var pro= AppDbContext.Db.Queryable<Io_pro_details>().Select(x => x.proCode).ToList();
                Product=new ObservableCollection<string>(pro);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Command
        private DelegateCommand<object> _SelectedProItemCommand;
        /// <summary>
        /// 选择产品型号
        /// </summary>
      
        public DelegateCommand<object> SelectedProItemCommand => _SelectedProItemCommand ?? (_SelectedProItemCommand = new DelegateCommand<object>(SelectedProItem));
        private void SelectedProItem(object parameter)
        {
            if(parameter == null)return;
            string par=parameter as string;
            IsEnable = false;
            try
            {


                ProuductId = Convert.ToInt32( AppDbContext.Db.Queryable<Io_pro_details>().Where(x => x.proCode == par).Select(x => x.ID).First());
                var prc = AppDbContext.Db.Queryable<Io_prc_product>().Where(x => x.Product == ProuductId).ToList();
                Prcess=new ObservableCollection<Io_prc_product>(prc);

                //获取齐套
               var  proid = AppDbContext.Db.Queryable<Io_pro_details>().Where(x=>x.proCode== par).Select(x => x.ID).First();
                int re = AppDbContext.Db.Queryable<Io_pro_CompleteSet>().Where(x => x.Product == proid).Count();
                if (re == 0)
                {
                    List<Boom> booms = AppDbContext.Db.Queryable<Boom>().Where(x => x.母件编码 == par&&x.主辅标识=="辅").ToList();
                    foreach (var item in booms)
                    {
                        Io_pro_CompleteSet io_Pro_CompleteSet = new Io_pro_CompleteSet()
                        {
                            mal_type = item.子件类别,
                            mal_code = item.子件编码,
                            mal_flag = item.主辅标识,
                            mal_name = item.子件名称,
                            mal_num = item.数量,
                            Product = proid,
                            mal_lastnum=item.数量,
                        };
                        AppDbContext.Db.Insertable(io_Pro_CompleteSet).ExecuteCommand();
                    }
                }
               var procls=AppDbContext.Db.Queryable<Io_pro_CompleteSet>().Where(x=>x.Product==proid).ToList();
                Pro_CompleteSets = new ObservableCollection<Io_pro_CompleteSet>(procls);
                _regionManager.Regions["PersonDetailsRegion"].RemoveAll();

            }
            catch (Exception)
            {

              
            }

        }



      

        private DelegateCommand<object> _SelectedPrcItemCommand;
        /// <summary>
        /// 选择工序
        /// </summary>
        public DelegateCommand<object> SelectedPrcItemCommand => _SelectedPrcItemCommand ?? (_SelectedPrcItemCommand = new DelegateCommand<object>(SelectedPrcItem));
        private void SelectedPrcItem(object parameter)
        {
            if(parameter==null)return;
           IsEnable = true;
            io_Prc_Product1 = parameter as Io_prc_product;
         OpenTabItem(io_Prc_Product1);
          
        }


        private Io_prc_product io_Prc_Product1;

       


        private DelegateCommand<object> _AddCraftCommand;
        /// <summary>
        /// 配置工艺
        /// </summary>
        public DelegateCommand<object> AddCraftCommand => _AddCraftCommand ?? (_AddCraftCommand = new DelegateCommand<object>(AddCraft));
        private async void AddCraft(object parameter)
        {
            if (parameter == null) return;
            var res = parameter as Io_pro_CompleteSet;
            if (res.mal_lastnum > 0)
            {
                DialogParameters param = new DialogParameters();
                param.Add("Value", res);
                var resDialog = await _dialogHostService.ShowDialog("AddProcessDialogView", param);
                if (resDialog.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                try
                {
                    var prcSt = resDialog.Parameters.GetValue<Io_prc_standard>("Prc_Standard");
                    if(io_Prc_Product1 == null)
                    {
                        MessageBox.Show("请选择要配置工艺的工序");
                    }
                    else
                    {
                        prcSt.PrcId = io_Prc_Product1.ID;

                        io_Prc_Product1.StanardList = new List<Io_prc_standard>();
                        io_Prc_Product1.StanardList.Add(prcSt);
                        AppDbContext.Db.InsertNav(io_Prc_Product1).Include(s => s.StanardList).ExecuteCommand();

                        OpenTabItem(io_Prc_Product1);
                        var procls = AppDbContext.Db.Queryable<Io_pro_CompleteSet>().Where(x => x.Product == io_Prc_Product1.Product).ToList();
                        Pro_CompleteSets = new ObservableCollection<Io_pro_CompleteSet>(procls);

                        Check();
                    }
                  

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("此物料已使用完成");
            }
          

        }


        #endregion
    }
}
