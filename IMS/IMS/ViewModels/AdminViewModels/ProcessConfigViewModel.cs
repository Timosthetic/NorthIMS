using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using Infrastructure.DialogHelper;
using Infrastructure.Dto;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

namespace IMS.ViewModels.AdminViewModels
{
    public class ProcessConfigViewModel : BindableBase
    {

        private readonly IDialogHostService _dialogHostService;
        public SnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();
      
        public ProcessConfigViewModel(IContainerExtension container)
        {
            _dialogHostService = container.Resolve<IDialogHostService>();
           
            Loadcodes();
            IsEnable = false;
           
        }
        #region Files
        private ObservableCollection<Io_pro_details> _productCode;
        /// <summary>
        /// 产品集合及状态
        /// </summary>
        public ObservableCollection<Io_pro_details> ProductCode
        {
            get { return _productCode; }
            set { SetProperty(ref _productCode, value); }
        }

       
        private ObservableCollection<Io_prc_product> _prcProduct;
        /// <summary>
        /// 产品工序
        /// </summary>
        public ObservableCollection<Io_prc_product> Prc_Products
        {
            get { return _prcProduct; }
            set { SetProperty(ref _prcProduct, value); }
        }
        private Io_prc_product _prc;
        /// <summary>
        /// 当前操作的工序
        /// </summary>
        public Io_prc_product Prc 
        {
            get { return _prc; }
            set { SetProperty(ref _prc, value); }


        }


      



        private Io_pro_details selected;

        private bool _IsEnable=false;
        /// <summary>
        /// 在为选中产品型号不可以创建工序
        /// </summary>
        public bool IsEnable
        {
            get { return _IsEnable; }
            set { SetProperty(ref _IsEnable, value); }
        }
        private string _proInfo;
        /// <summary>
        /// 当前选中的产品型号
        /// </summary>
        public string ProInfo
        {
            get { return _proInfo; }
            set { SetProperty(ref _proInfo, value); }
        }



        #endregion

        #region Command

        private DelegateCommand<object> _AddDealProductCommand;
        /// <summary>
        /// 添加工序
        /// </summary>
        public DelegateCommand<object> AddDealProductCommand => _AddDealProductCommand ?? (_AddDealProductCommand = new DelegateCommand<object>(AddDealProduct));
        private async void AddDealProduct(object parameter)
        {
            if (parameter == null) return;
            var io_Pro_Details = parameter as Io_pro_details;
              var resDialog = await _dialogHostService.ShowDialog("AUProcessConfigView", null);
            if (resDialog.Result != ButtonResult.OK) return;
            try
            {
                var todo = resDialog.Parameters.GetValue<Io_prc_product>("UpdateValue1");
                if (todo.ID == 0)
                {
                    var res = AppDbContext.Db.Queryable<Io_prc_product>().Where(x => x.Product == io_Pro_Details.ID).Max(x => x.Node);
                    todo.Node = res + 1;
                    todo.Product = io_Pro_Details.ID;
                    todo.User_create = ConfigurationHelper.ReadSetting("UserNum");
                    AppDbContext.Db.Insertable(todo).ExecuteCommand();
                }

                Refresh();
            }
            catch (Exception ex)
            {
                Log.Error($"添加或更改工序失败，原因：{ex.Message}");

            }
         

         

          
         
        }
        private DelegateCommand<object> _DeleteDealProductCommand;
        /// <summary>
        /// 删除产品的相关信息 包括上传的BOM信息
        /// </summary>
        public DelegateCommand<object> DeleteDealProductCommand => _DeleteDealProductCommand ?? (_DeleteDealProductCommand = new DelegateCommand<object>(DeleteDealProduct));
        private void DeleteDealProduct(object parameter)
        {
            try
            {
                if (MessageBox.Show("确定要删除此产品及所有相关信息嘛?", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {

                    //删除当前产品的工序工艺以及产品本身
                 AppDbContext.Db.DeleteNav<Io_prc_product>(x => x.Pro_Detail.ID == selected.ID)
                        .Include(p => p.Pro_Detail)
                        .Include(s => s.StanardList).ExecuteCommand();
                    AppDbContext.Db.Deleteable<Io_pro_details>(x => x.ID == selected.ID).ExecuteCommand();
                    //删除此产品在BOM中的信息
                    AppDbContext.Db.Deleteable<Boom>(x => x.母件编码 == selected.proCode).ExecuteCommand();
                    //删除此产品的齐套标准
                    AppDbContext.Db.Deleteable<Io_pro_CompleteSet>(x=>x.Product== selected.ID).ExecuteCommand();
                    Refresh();
                    var product = AppDbContext.Db.Queryable<Io_pro_details>().ToList();
                    ProductCode = new ObservableCollection<Io_pro_details>(product);
                }
            }
            catch (Exception ex)
            {

                Log.Error($"删除产品失败，原因：{ex.Message}");
            }
        }





        private DelegateCommand<object> _SelectedItemEventCommand;
        /// <summary>
        /// 获取产品工序节点信息
        /// </summary>
        public DelegateCommand<object> SelectedItemEventCommand => _SelectedItemEventCommand ?? (_SelectedItemEventCommand = new DelegateCommand<object>(SelectedItemEvent));
        private void SelectedItemEvent(object parameter)
        {
            if (parameter == null) return;
             selected=parameter as Io_pro_details;
            ProInfo = selected.proCode;
            Prc = new Io_prc_product();
            IsEnable = true;
            Refresh();

           
        }



        private DelegateCommand<object> _EditDealProcessCommand;
        /// <summary>
        /// 编辑工序
        /// </summary>
        public DelegateCommand<object> EditDealProcessCommand => _EditDealProcessCommand ?? (_EditDealProcessCommand = new DelegateCommand<object>(EditDealProcess));
        private async void EditDealProcess(object parameter)
        {
            DialogParameters parm = new DialogParameters();
            if (parameter != null) parm.Add("UpdateValue1", parameter as Io_prc_product);
          
          
            var resDialog = await _dialogHostService.ShowDialog("AUProcessConfigView", parm);
            if (resDialog.Result != ButtonResult.OK) return;
            try
            {
                var todo = resDialog.Parameters.GetValue<Io_prc_product>("UpdateValue1");
                if (todo.ID != 0)
                {
                    
                    todo.User_create = ConfigurationHelper.ReadSetting("UserNum");
                    AppDbContext.Db.Updateable(todo).ExecuteCommand();
                }

                Refresh();
            }
            catch (Exception ex)
            {
                Log.Error($"更改工序失败，原因：{ex.Message}");

            }

        }


        private DelegateCommand<object> _DeleteDealProcessCommand;
        /// <summary>
        /// 删除工序
        /// </summary>
        public DelegateCommand<object> DeleteDealProcessCommand => _DeleteDealProcessCommand ?? (_DeleteDealProcessCommand = new DelegateCommand<object>(DeleteDealProcess));
        private void DeleteDealProcess(object parameter)
        {
            if (parameter == null) return;
            var process = parameter as Io_prc_product;
            try
            {
                if (MessageBox.Show("确定要删除此产品及所有相关信息嘛?", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    AppDbContext.Db.DeleteNav<Io_prc_product>(x => x.ID == process.ID)
                           .Include(s => s.StanardList).ExecuteCommand();
                   
                    Refresh();
                }
            }
            catch (Exception ex)
            {

                Log.Error($"删除产品失败，原因：{ex.Message}");
            }
        }





        #endregion


        #region Method
        /// <summary>
        /// 加载数据
        /// </summary>
        private void Loadcodes()
        {
            try
            {
                
                List<string> dbprocodes = AppDbContext.Db.Queryable<Boom>().Distinct().Select(it => it.母件编码).ToList();
                var proCode = AppDbContext.Db.Queryable<Io_pro_details>().Select(x => x.proCode).ToList();
                var tinct = dbprocodes.Where(x => !proCode.Exists(t => x.Contains(t))).ToList();

                if (tinct.Count > 0)
                {
                 
                    foreach (var t in tinct)
                    {
                        Io_pro_details res = new Io_pro_details()
                        {
                            proCode = t,
                            proName = AppDbContext.Db.Queryable<Boom>().Where(x => x.母件编码 == t).Select(x=>x.母件名称).First(),
                        };
                     
                        AppDbContext.Db.Insertable(res).ExecuteCommand();
                    }




                }
                var Io_pro_de = AppDbContext.Db.Queryable<Io_pro_details>().ToList();

                ProductCode = new ObservableCollection<Io_pro_details>(Io_pro_de);
           
            }
            catch (Exception ex)
            {

                Log.Error($"加载产品数据失败：原因{ex.Message}");
            }
          
          


        }
        private void Refresh()
        {
            try
            {
                var res = AppDbContext.Db.Queryable<Io_prc_product>()
                    .Mapper(x => x.Pro_Detail, x => x.Product)
                    .Where(x => x.Pro_Detail.ID == selected.ID)
                    .ToList();


                Prc_Products = new ObservableCollection<Io_prc_product>(res);

            }
            catch (Exception ex)
            {

                Log.Error($"查询{selected.proCode}此产品工序失败，原因：{ex.Message}");
            }
        }
        #endregion
    }
}
