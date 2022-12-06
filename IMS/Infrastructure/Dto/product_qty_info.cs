using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("product_qty_info")]
    public class product_qty_info : NotifyPropertyChanged
    {

        private int _Id;
        private string _项目号;
        private string _工单号;
        private string _图号;
        private string _产成品名称;
        private string _产成品SN;
        private DateTime _测试时间;
        private int _实时过站工位;
        private string _箱体标签;
        private string _载具ID;


        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "project_no")]
        public string 项目号 { get => _项目号; set => SetProperty(ref _项目号, value); }
        [SugarColumn(ColumnName = "po_no")]
        public string 工单号 { get => _工单号; set => SetProperty(ref _工单号, value); }

        [SugarColumn(ColumnName = "product_code")]
        public string 图号 { get => _图号; set => SetProperty(ref _图号, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 产成品名称 { get => _产成品名称; set => SetProperty(ref _产成品名称, value); }
        [SugarColumn(ColumnName = "product_sn")]
        public string 产成品SN { get => _产成品SN; set => SetProperty(ref _产成品SN, value); }
        [SugarColumn(ColumnName = "boxlabel")]
        public string 箱体标签 { get => _箱体标签; set => SetProperty(ref _箱体标签, value); }
        [SugarColumn(ColumnName = "tray")]
        public string 载具ID { get => _载具ID; set => SetProperty(ref _载具ID, value); }
        [SugarColumn(ColumnName = "station_realtime")]
        public int 实时过站工位 { get => _实时过站工位; set => SetProperty(ref _实时过站工位, value); }
        [SugarColumn(ColumnName = "testtime")]
        public DateTime 测试时间 { get => _测试时间; set => SetProperty(ref _测试时间, value); }



    }
}
