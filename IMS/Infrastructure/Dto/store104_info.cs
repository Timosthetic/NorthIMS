using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("store104_info")]
    public class store104_info : NotifyPropertyChanged
    {

        private int _Id;
        private string _库位;
        private string _是否已占用;
        private string _载具ID;
        private string _箱体标签;

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "adr")]//数据库与实体不一样设置列名 
        public string 库位 { get => _库位; set => SetProperty(ref _库位, value); }
        [SugarColumn(ColumnName = "flag")]
        public string 是否已占用 { get => _是否已占用; set => SetProperty(ref _是否已占用, value); }
        [SugarColumn(ColumnName = "tray")]
        public string 载具ID { get => _载具ID; set => SetProperty(ref _载具ID, value); }
        [SugarColumn(ColumnName = "boxlabel")]
        public string 箱体标签 { get => _箱体标签; set => SetProperty(ref _箱体标签, value); }
    }
}
