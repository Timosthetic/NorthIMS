using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("product_station_order")]
    public class product_station_order : NotifyPropertyChanged
    {

        private int _Id;
        private string _母件编码;
        private string _母件名称;
        private string _流转路线;
        private DateTime _创建时间;
        private string _创建人员;
        private string _freeze;

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "product_code")]
        public string 母件编码 { get => _母件编码; set => SetProperty(ref _母件编码, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 母件名称 { get => _母件名称; set => SetProperty(ref _母件名称, value); }

        [SugarColumn(ColumnName = "stationorder_desc")]
        public string 流转路线 { get => _流转路线; set => SetProperty(ref _流转路线, value); }
        [SugarColumn(ColumnName = "create_time")]
        public DateTime 创建时间 { get => _创建时间; set => SetProperty(ref _创建时间, value); } 
        [SugarColumn(ColumnName = "create_user")]
        public string 创建人员 { get => _创建人员; set => SetProperty(ref _创建人员, value); }
        public string freeze { get => _freeze; set => SetProperty(ref _freeze, value); }

    }
}
