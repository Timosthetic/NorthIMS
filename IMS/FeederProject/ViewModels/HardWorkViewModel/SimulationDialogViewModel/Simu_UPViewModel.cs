using Infrastructure.DialogHelper;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FeederProject.ViewModels.HardWorkViewModel.SimulationDialogViewModel
{
    public class Simu_UPViewModel : BindableBase, IDialogHostAware
    {
        public Simu_UPViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            var res=  AppDbContext.Db.Queryable<DataTraceability>().ToList();
            DataTraceabilities = new ObservableCollection<DataTraceability>(res);
        }

        private ObservableCollection<DataTraceability> _datatraceability;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<DataTraceability> DataTraceabilities
        {
            get { return _datatraceability; }
            set { SetProperty(ref _datatraceability, value); }
        }

        private DataTraceability _selectedItem;
        /// <summary>
        /// 
        /// </summary>
        public DataTraceability SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }















        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

        private void Save()
        {
            if (!DialogHost.IsDialogOpen(DialogHostName)) return;
            DialogParameters param = new DialogParameters();
            if (SelectedItem!=null)
            {


              var bingding=  AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => string.IsNullOrEmpty(x.serial_num)).First();
                if (bingding != null)
                {
                    bingding.serial_num = SelectedItem.serial_num;
                    bingding.circulation_st = SelectedItem.station;
                    bingding.workorder = SelectedItem.work_order;
                    bingding.await_st = SelectedItem.station;
                    //AppDbContext.Db.Updateable(bingding).ExecuteCommandAsync();
                    param.Add("ProInfo", SelectedItem);
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
                }

                
              
             
            }
            else
            {
                //BoundMessageQueue.Enqueue("剩余的齐套数量小于配置的齐套数量");
            }
        }
        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)
        {
            

        }

    }
}
