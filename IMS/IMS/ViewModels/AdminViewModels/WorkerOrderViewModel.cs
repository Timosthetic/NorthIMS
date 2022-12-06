using Infrastructure.DialogHelper;
using Infrastructure.Dto;
using Infrastructure.Helper;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Mvvm;
using System.Windows;
using Serilog;
using Infrastructure.Dto.NewDto;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.XlsIO;
using System.IO;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Grid.Converter;

namespace IMS.ViewModels.AdminViewModels
{
    public class WorkerOrderViewModel:BindableBase
    {
        private readonly IDialogHostService _dialogHostService;
        public WorkerOrderViewModel(IContainerExtension container)
        {
            _dialogHostService = container.Resolve<IDialogHostService>();
            Refresh();
        }

        #region Method
        private void Refresh()
        {
            var refresh = AppDbContext.Db.Queryable<po_info>().ToList();
            Po_Infos = new ObservableCollection<po_info>(refresh);
        }
        #endregion
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
        private po_info _SelectedOrder;
        /// <summary>
        /// 
        /// </summary>
        public po_info SelectedOrder
        {

            get { return _SelectedOrder; }
            set { SetProperty(ref _SelectedOrder, value); }
        }


        #endregion
        #region Command
       
        private DelegateCommand _AddCommand;
        /// <summary>
        /// 添加工单
        /// </summary>
        public DelegateCommand AddCommand => _AddCommand ?? (_AddCommand = new DelegateCommand(async() =>
        {
           
            var resDialog = await _dialogHostService.ShowDialog("WorkOrderDialogView", null);
            if (resDialog.Result != ButtonResult.OK) return;
            try
            {
                var todo = resDialog.Parameters.GetValue<po_info>("UpdateValue");
                if (todo.Id == 0)
                {
                    AppDbContext.Db.Insertable(todo).ExecuteCommand();
                }
              
                Refresh();
            }
            catch (Exception)
            {


            }
        }));


        private DelegateCommand<object> _excelCommand;
        /// <summary>
        /// 导出数据
        /// </summary>
        public DelegateCommand<object> ExcelCommand => _excelCommand ?? (_excelCommand = new DelegateCommand<object>(Excel));
        private void Excel(object parameter)
        {
            //筛选数据
            //dt_Trace_Tracks = new List<dt_Trace_Track>();
            //var records = (parameter as SfDataGrid).View.Records;
            //foreach (RecordEntry record in records)
            //    dt_Trace_Tracks.Add(record.Data as dt_Trace_Track);
            var dataGrid = parameter as SfDataGrid;



            var options = new ExcelExportingOptions();
            options.ExportAllPages = true;
            options.ExcelVersion = ExcelVersion.Excel2013;
            var excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];

            SaveFileDialog sfd = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {

                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;

                    else if (sfd.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;

                    else
                        workBook.Version = ExcelVersion.Excel2013;
                    workBook.SaveAs(stream);
                    MessageBox.Show("数据导出完成...");
                }


            }

        }

        private DelegateCommand<object> _EditCommand;
        /// <summary>
        /// 编辑工单
        /// </summary>
        public DelegateCommand<object> EditCommand => _EditCommand ?? (_EditCommand = new DelegateCommand<object>(Edit));
        private async void Edit(object parameter)
        {
            if(parameter == null)
            {
                MessageBox.Show("请选中要操作的项");

            }
            else
            {
                DialogParameters parm = new DialogParameters();
                if (parameter != null) parm.Add("UpdateValue", parameter as po_info);
                var resDialog = await _dialogHostService.ShowDialog("WorkOrderDialogView", parm);
                if (resDialog.Result != ButtonResult.OK) return;
                try
                {
                    var todo = resDialog.Parameters.GetValue<po_info>("UpdateValue");
                    AppDbContext.Db.Updateable(todo).ExecuteCommand();
                    Refresh();
                }
                catch (Exception)
                {


                }
            }
        }
        private DelegateCommand<object> _DeleteCommand;
        /// <summary>
        /// 删除
        /// </summary>
        public DelegateCommand<object> DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new DelegateCommand<object>(Delete));
        private  void Delete(object parameter)
        {
            if (parameter == null)
            {
                MessageBox.Show("请选中要操作的项");

            }
            else
            {
                var res = parameter as po_info;
                if (MessageBox.Show($"是否要删除任务/工单:{res.工单号}信息？", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        if (res.工单状态 == "已完成")
                        {
                            AppDbContext.Db.Deleteable<DataTraceability>(x => x.work_order == res.工单号).ExecuteCommand();
                            AppDbContext.Db.Deleteable(res).ExecuteCommand();
                            Refresh();
                        }
                        else
                        {
                            MessageBox.Show("仅可以删除已完成的工单");
                        }
                       
                    }
                    catch (Exception ex)
                    {

                        Log.Error($"删除工单:{res.工单号}失败，原因{ex.Message}");
                    }

                }
                else
                {
                    ;

                }
               
            }
        }
        private DelegateCommand<object> _StartCommand;
        /// <summary>
        /// 工单上线中
        /// </summary>
        public DelegateCommand<object> StartCommand => _StartCommand ?? (_StartCommand = new DelegateCommand<object>(Start));
        private async void Start(object parameter)
        {
            if (parameter == null)
            {
                MessageBox.Show("请选中要操作的项");

            }
            else
            {
              
                try
                {
                   var res=parameter as po_info;
               var woStatus=   await  AppDbContext.Db.Queryable<po_info>().Where(x => x.Id == res.Id).Select(x=>x.工单状态).SingleAsync();
                    if(woStatus== "已完成")
                    {
                        MessageBox.Show($"此任务/工单号:{res.工单号}已中止再次使用");
                    }
                    else
                    {
                        if (res.工单状态 == "暂停")
                        {
                            res.工单状态 = "上线中";
                        }
                        else
                        {
                            //未打印标签的开始工单状态为缺料
                            res.工单状态 = "缺料";
                        }
                       

                        AppDbContext.Db.Updateable(res).ExecuteCommand();

                        Refresh();
                    }
                   
                }
                catch (Exception)
                {


                }
            }
        }
        private DelegateCommand<object> _PauseCommand;
        /// <summary>
        /// 工单暂停
        /// </summary>
        public DelegateCommand<object> PauseCommand => _PauseCommand ?? (_PauseCommand = new DelegateCommand<object>(Pause));
        private async void Pause(object parameter)
        {
            if (parameter == null)
            {
                MessageBox.Show("请选中要操作的项");

            }
            else
            {

                try
                {
                    var res = parameter as po_info;
                    var woStatus = await AppDbContext.Db.Queryable<po_info>().Where(x => x.Id == res.Id).Select(x => x.工单状态).SingleAsync();
                    if (woStatus == "已完成")
                    {
                        MessageBox.Show($"此任务/工单号:{res.工单号}已中止再次使用");
                    }
                    else
                    {
                        res.工单状态 = "暂停";

                        AppDbContext.Db.Updateable(res).ExecuteCommand();

                        Refresh();
                    }
                  
                  
                }
                catch (Exception)
                {


                }
            }
        }
        private DelegateCommand<object> _StopCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<object> StopCommand => _StopCommand ?? (_StopCommand = new DelegateCommand<object>(Stop));
        private void Stop(object parameter)
        {
            if (parameter == null)
            {
                MessageBox.Show("请选中要操作的项");

            }
            else
            {
                var res = parameter as po_info;
                if (MessageBox.Show($"是否要中止任务/工单:{res.工单号}信息？", "温馨提示:中止后的工单禁止再次使用", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {

                        res.工单状态 = "已完成";

                        AppDbContext.Db.Updateable(res).ExecuteCommand();

                        Refresh();
                    }
                    catch (Exception)
                    {


                    }

                }
                else
                {
                    ;

                }
             
            }
        }


        private DelegateCommand _RefreshCommand;
        /// <summary>
        /// 刷新数据
        /// </summary>
        public DelegateCommand RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new DelegateCommand(() =>
        {
            Refresh();
        }));



        #endregion
    }
}
