using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("product_manhour_info")]
    public class product_manhour_info : NotifyPropertyChanged
    {


        private int _Id;
        private string _项目号;
        private string _工单号;
        private string _产成品SN;
        private string _图号;
        private string _产成品名称;
        private DateTime _测试时间;
        private int _工位号;
        private string _工位描述;
        private float _等待工时;
        private float _装配工时;
        private string _员工号;
        private string _员工姓名;


        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "project_no")]
        public string 项目号 { get => _项目号; set => SetProperty(ref _项目号, value); }
        [SugarColumn(ColumnName = "po_no")]
        public string 工单号 { get => _工单号; set => SetProperty(ref _工单号, value); }
        [SugarColumn(ColumnName = "product_sn")]
        public string 产成品SN { get => _产成品SN; set => SetProperty(ref _产成品SN, value); }
        [SugarColumn(ColumnName = "product_code")]
        public string 图号 { get => _图号; set => SetProperty(ref _图号, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 产成品名称 { get => _产成品名称; set => SetProperty(ref _产成品名称, value); }

        [SugarColumn(ColumnName = "testtime")]
        public DateTime 测试时间 { get => _测试时间; set => SetProperty(ref _测试时间, value); } 
        [SugarColumn(ColumnName = "station_id")]
        public int 工位号 { get => _工位号; set => SetProperty(ref _工位号, value); }
        [SugarColumn(ColumnName = "station_desc")]
        public string 工位描述 { get => _工位描述; set => SetProperty(ref _工位描述, value); }
        [SugarColumn(ColumnName = "wait_time")]
        public float 等待工时 { get => _等待工时; set => SetProperty(ref _等待工时, value); }
        [SugarColumn(ColumnName = "assemble_time")]
        public float 装配工时 { get => _装配工时; set => SetProperty(ref _装配工时, value); }
        [SugarColumn(ColumnName = "op_no")]
        public string 员工号 { get => _员工号; set => SetProperty(ref _员工号, value); }
        [SugarColumn(ColumnName = "op_name")]
        public string 员工姓名 { get => _员工姓名; set => SetProperty(ref _员工姓名, value); }
    }
}
