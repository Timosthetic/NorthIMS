using Infrastructure.DialogHelper;
using Infrastructure.Dto.NewDto;
using Infrastructure.Event;
using Infrastructure.Helper;
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
using System.Text;
using System.Windows;

namespace IMS.ViewModels.DialogViewModels
{
    public  class PrcCraftTabViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogHostService _dialogHostService;
        private readonly IEventAggregator ea;

        public PrcCraftTabViewModel(IContainerExtension container, IEventAggregator ea)
        {
            _dialogHostService = container.Resolve<IDialogHostService>();
            this.ea = ea;
        }


        private Io_prc_product _selectedProcess;
        /// <summary>
        /// 工序
        /// </summary>
        public Io_prc_product SelectedProcess
        {
            get { return _selectedProcess; }
            set { SetProperty(ref _selectedProcess, value); }
        }
        private ObservableCollection<Io_prc_standard> _PrcConfig;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Io_prc_standard> PrcConfig
        {
            get { return _PrcConfig; }
            set { SetProperty(ref _PrcConfig, value); }
        }



        public bool IsNavigationTarget(NavigationContext navigationContext)
        {

            var process = navigationContext.Parameters["prcName"] as Io_prc_product;
            if (process != null)
               
                return SelectedProcess!=null&&SelectedProcess.ID==process.ID;
            else
                return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

            var process = navigationContext.Parameters["prcName"] as Io_prc_product;
            if (process != null)
                SelectedProcess = process;
            PrcConfig = new ObservableCollection<Io_prc_standard>(SelectedProcess.StanardList);

        }



        private DelegateCommand<object> _EditDealCraftCommand;
        /// <summary>
        /// 编辑工艺
        /// </summary>
        public DelegateCommand<object> EditDealCraftCommand => _EditDealCraftCommand ?? (_EditDealCraftCommand = new DelegateCommand<object>(EditDealCraft));
        private async void EditDealCraft(object parameter)
        {
            DialogParameters parm = new DialogParameters();
            if (parameter != null) parm.Add("Prc_Standard", parameter as Io_prc_standard);


            var resDialog = await _dialogHostService.ShowDialog("EditProcessDialogView", parm);
            if (resDialog.Result != ButtonResult.OK) return;
            try
            {
                var todo = resDialog.Parameters.GetValue<Io_prc_standard>("Prc_Standard");
                if (todo.ID != 0)
                {

                 
                    AppDbContext.Db.Updateable(todo).ExecuteCommand();
                    var comp = AppDbContext.Db.Queryable<Io_pro_CompleteSet>().Where(x => x.mal_code == todo.Materiel).First();
                    comp.mal_lastnum += todo.Atprule;
                    AppDbContext.Db.Updateable(comp).ExecuteCommand();
                    ea.GetEvent<EventRefresh>().Publish();
                }

             
            }
            catch (Exception ex)
            {
                Log.Error($"更改工艺失败，原因：{ex.Message}");

            }
            Refresh();
        }


        private DelegateCommand<object> _DeleteDealCraftCommand;
        /// <summary>
        /// 删除工序
        /// </summary>
        public DelegateCommand<object> DeleteDealCraftCommand => _DeleteDealCraftCommand ?? (_DeleteDealCraftCommand = new DelegateCommand<object>(DeleteDealCraft));
        private void DeleteDealCraft(object parameter)
        {
           
            try
            {
                if (MessageBox.Show("确定要删除工艺信息嘛?", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (parameter == null) return;
                    var res = parameter as Io_prc_standard;
                    AppDbContext.Db.Deleteable<Io_prc_standard>(res).ExecuteCommand();
                   var comp= AppDbContext.Db.Queryable<Io_pro_CompleteSet>().Where(x => x.mal_code == res.Materiel).First();
                    comp.mal_lastnum += res.Atprule;
                    AppDbContext.Db.Updateable(comp).ExecuteCommand();
                    ea.GetEvent<EventRefresh>().Publish();
                }
            }
            catch (Exception ex)
            {

                Log.Error($"删除工艺失败，原因：{ex.Message}");
            }
            Refresh();
        }

        #region Method
        private async void Refresh()
        {
            try
            {
             

                var res = await AppDbContext.Db.Queryable<Io_prc_standard>().Where(x => x.PrcId == SelectedProcess.ID).ToListAsync();
                PrcConfig=new ObservableCollection<Io_prc_standard>(res);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

    }
}
