using Infrastructure.Dto.NewDto;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Infrastructure.DealWithFile;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Grid.Converter;

namespace IMS.Views.AdminViews
{
    /// <summary>
    /// DatenverfolgungView.xaml 的交互逻辑
    /// </summary>
    public partial class DatenverfolgungView : UserControl
    {
        public DatenverfolgungView()
        {
            InitializeComponent();
        }
        private List<dt_Trace_Track> dt_Trace_Tracks;
        private void SfDataGrid_FilterChanged(object sender, Syncfusion.UI.Xaml.Grid.GridFilterEventArgs e)
        {
            dt_Trace_Tracks = new List<dt_Trace_Track>();
            var records = (sender as SfDataGrid).View.Records;

            foreach (RecordEntry record in records)
                dt_Trace_Tracks.Add(record.Data as dt_Trace_Track);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dt_Trace_Tracks.Count > 0)
            {

                var options = new ExcelExportingOptions();
                options.ExportAllPages = true;
                var excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);
                var workBook = excelEngine.Excel.Workbooks[0];
                workBook.SaveAs(@"C: \Users\kstopa\Desktop\Sample.xlsx");

                //SaveFileDialog dlg = new SaveFileDialog();
                //dlg.FileName = DateTime.Now.ToString("yyyyMMdd") + ".xlsx"; // Default file name
                //dlg.DefaultExt = ".xlsx"; // Default file extension
                //dlg.Filter = "xls documents (.xlsx)|*.xlsx"; // Filter files by extension

                //var dir = Path.GetDirectoryName(@"C:\\Data\\");
                //dlg.InitialDirectory = dir;

                //// Show save file dialog box
                //Nullable<bool> result = dlg.ShowDialog();

                //// Process save file dialog box results
                //if (result == true)
                //{
                //    // Save document
                //    string path = dlg.FileName;
                //    ExcelHelper.CreateExcelByList(path, dt_Trace_Tracks);
                //    MessageBox.Show("温馨提示", "数据导出完成");

                //}
                //else
                //{
                //    MessageBox.Show("温馨提示", "请先查询后导出，并确保有数据导出");

                //}
            }
            else
            {
                MessageBox.Show("请筛选出符合条件的数据,如全部导出会导致数据量过于庞大");
            }

        }




    }
}
