using Infrastructure.Helper.Notify;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Infrastructure.Dto
{
    [SugarTable("user_info")]
    public class User : NotifyPropertyChanged
    {
        private int _Id;
        private string _员工号;
        private string _姓名;
        private int _权限代码;
        private string _权限描述;
        private string _授权人员工号;
        private string _授权人姓名;
        private string _密码;
        private DateTime _更新时间 = DateTime.UtcNow;
        private string _冻结列 = "";


        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "op_no")]//数据库与实体不一样设置列名 
        public string 员工号 { get => _员工号; set => SetProperty(ref _员工号, value); }
        [SugarColumn(ColumnName = "op_name")]
        public string 姓名 { get => _姓名; set => SetProperty(ref _姓名, value); }
        [SugarColumn(ColumnName = "right_id")]
        public int 权限代码 { get => _权限代码; set => SetProperty(ref _权限代码, value); }
        [SugarColumn(ColumnName = "right_desc")]
        public string 权限描述 { get => _权限描述; set => SetProperty(ref _权限描述, value); }
        [SugarColumn(ColumnName = "master_no")]
        public string 授权人员工号 { get => _授权人员工号; set => SetProperty(ref _授权人员工号, value); }
        [SugarColumn(ColumnName = "master_name")]
        public string 授权人姓名 { get => _授权人姓名; set => SetProperty(ref _授权人姓名, value); }
        [SugarColumn(ColumnName = "pw")]
        public string 密码 { get => _密码; set => SetProperty(ref _密码, value); }
        [SugarColumn(ColumnName = "updatetime")]
        public DateTime 更新时间 { get => _更新时间; set => SetProperty(ref _更新时间, value); }
        [SugarColumn(ColumnName = "freeze")]
        public string 冻结列 { get => _冻结列; set => SetProperty(ref _冻结列, value); } 
    }



 
}
