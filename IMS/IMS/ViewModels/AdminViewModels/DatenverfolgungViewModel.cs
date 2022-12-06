using Infrastructure.DialogHelper;
using Infrastructure.Dto;
using Infrastructure.Dto.Login;
using Infrastructure.Dto.NewDto;
using Infrastructure.Extensions;
using Infrastructure.Helper;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Serilog;
using SqlSugar;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;

namespace IMS.ViewModels.AdminViewModels
{
    public class DatenverfolgungViewModel:BindableBase
    {

        public DatenverfolgungViewModel()
        {
            Reshfrsh();
        }


        private void Reshfrsh()
        {
            try
            {
                var res = AppDbContext.Db.Queryable<dt_Trace_Track>().ToList();
                Dt_Trace_Track = new ObservableCollection<dt_Trace_Track>(res);
            }
            catch (Exception ex)
            {

                Log.Error($"获取生产实时数据失败，原因:{ex.Message}");
            }
        }
       
        private ObservableCollection<dt_Trace_Track> _dtTraceTrack;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<dt_Trace_Track> Dt_Trace_Track

        {
            get { return _dtTraceTrack; }
            set { SetProperty(ref _dtTraceTrack, value); }
        }
     
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

    }
}
