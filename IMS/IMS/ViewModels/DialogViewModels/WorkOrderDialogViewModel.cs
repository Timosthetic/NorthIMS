using Infrastructure.DialogHelper;
using Infrastructure.Dto;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using System.Collections.ObjectModel;

namespace IMS.ViewModels.DialogViewModels
{
    public class WorkOrderDialogViewModel : BindableBase, IDialogHostAware
    {
        public WorkOrderDialogViewModel()
        {

            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            var proList=AppDbContext.Db.Queryable<Io_pro_details>().ToList();
            ProType = new ObservableCollection<Io_pro_details>(proList);
          
          
        }

        private po_info _orderInfo;
        /// <summary>
        /// 工单信息
        /// </summary>
        public po_info OrderInfo
        {
            get { return _orderInfo; }
            set { SetProperty(ref _orderInfo, value); }
        }
        private ObservableCollection<Io_pro_details> _ProType;
        /// <summary>
        /// 产品型号集合，母件编码
        /// </summary>
        public ObservableCollection<Io_pro_details> ProType
        {
            get { return _ProType; }
            set { SetProperty(ref _ProType, value); }
        }
       

        #region Command
        private DelegateCommand<object> _SelectedProItemCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<object> SelectedProItemCommand => _SelectedProItemCommand ?? (_SelectedProItemCommand = new DelegateCommand<object>(SelectedPro));
        private void SelectedPro(object parameter)
        {
            if(parameter == null)return;
            var res = parameter as Io_pro_details;
            var  StationList = AppDbContext.Db.Queryable<Io_prc_product>().Mapper(x => x.Pro_Detail, x => x.Product)
                .Where(x => x.Pro_Detail.ID == res.ID).Select(x => x.Station).ToList();
            OrderInfo.流转路线 =string.Join("→", StationList.ToArray());
            OrderInfo.图号 = res.proCode;
            OrderInfo.产成品名称=res.proName;
        }

        #endregion


        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

        private void Save()
        {
            if (!DialogHost.IsDialogOpen(DialogHostName)) return;
            DialogParameters param = new DialogParameters();

            if(!string.IsNullOrEmpty(OrderInfo.图号)&&!string.IsNullOrEmpty(OrderInfo.计划完工日期.ToString())
                && OrderInfo.工单数量 != 0 && !string.IsNullOrEmpty(OrderInfo.项目号) )
            {
             List<string> strings=new List<string>(   OrderInfo.流转路线.Split("→"));
                OrderInfo.工位利用率 = $"{strings.Count}/12";
                param.Add("UpdateValue", OrderInfo);
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }
            else
            {

            }
           
        }
        private bool _isEnable;
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }


        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)
        {

            OrderInfo = parameters.ContainsKey("UpdateValue") ? parameters.GetValue<po_info>("UpdateValue") : new po_info();
            if (OrderInfo.Id != 0)
            {
                IsEnable = false;
            }
            else
            {
                IsEnable = true;
            }
            //Prc_Standard = parameters.ContainsKey("Prc_Standard") ? parameters.GetValue<Io_prc_standard>("Prc_Standard") : new Io_prc_standard();
        }
    }
}
