using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using Infrastructure.Dto;
using Infrastructure.Helper;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Serilog;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using static System.Net.Mime.MediaTypeNames;

namespace IMS.ViewModels.AdminViewModels
{
    public class StaffMangeViewModel : BindableBase
    {
        public StaffMangeViewModel()
        {
            UserList = new ObservableCollection<User>(GetUserList());
            
        }
        #region Method
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        private List< User> GetUserList()
        {
           return AppDbContext.Db.Queryable<User>().ToList();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        private void AddUser()
        {
            if(SelectedIndex!=-1&&!string.IsNullOrEmpty(StaffName)&&!string.IsNullOrEmpty(StaffNum)
                && !string.IsNullOrEmpty(StaffPassword))
            {
            var res=  AppDbContext.Db.Queryable<User>().Where(it =>  it.员工号 ==StaffNum).Any();
                if (res)
                {
                    BoundMessageQueue.Enqueue("该员工信息已存在,请重新输入员工号");
                    StaffNum = "";
                  
                }
            }
            else
            {

                BoundMessageQueue.Enqueue("信息需要填写完整才可以添加用户");
            }
        }

        private void DeleteUser()
        {

        }


        private void UpdateUser()
        {

        }
        #endregion
        #region Files

        public SnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();
        private ObservableCollection<User> _userList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }
        private int _SelectedIndex;
        /// <summary>
        /// 权限
        /// </summary>
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set { SetProperty(ref _SelectedIndex, value); }
        }


        private string _StaffName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName
        {
            get { return _StaffName; }
            set { SetProperty(ref _StaffName, value); }
        }
        private string _StaffNum;
        /// <summary>
        /// 员工工号
        /// </summary>
        public string StaffNum
        {
            get { return _StaffNum; }
            set { SetProperty(ref _StaffNum, value); }
        }

        private string _permission;
        /// <summary>
        /// 权限
        /// </summary>
        public string permission
        {
            get { return _permission; }
            set { SetProperty(ref _permission, value); }
        }


        private string _StaffPassword="1234";
        /// <summary>
        /// 登录密码
        /// </summary>
        public string StaffPassword
        {
            get { return _StaffPassword; }
            set { SetProperty(ref _StaffPassword, value); }
        }


        #endregion

        private DelegateCommand<string> _ExcuteCommad;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> ExcuteCommad => _ExcuteCommad ?? (_ExcuteCommad = new DelegateCommand<string>(Excute));
        private void Excute(string parameter)
        {
            if (parameter == "add")
            {
               
                var re = SelectedIndex;
                AddUser();
                
            }

            else if (parameter== "update")
            {

            }
          
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
