using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("calculate_manhour_base")]
    public class calculate_manhour_base : NotifyPropertyChanged
    {

        private int _Id;
        private string _母件编码;
        private string _母件名称;
        private string _产成品SN;
        private int _工位号;
        private DateTime _入站时间;
        private DateTime _出站时间;
        private string _冻结标志;


        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "product_code")]//数据库与实体不一样设置列名 
        public string 母件编码 { get => _母件编码; set => SetProperty(ref _母件编码, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 母件名称 { get => _母件名称; set => SetProperty(ref _母件名称, value); }
        [SugarColumn(ColumnName = "product_sn")]
        public string 产成品SN { get => _产成品SN; set => SetProperty(ref _产成品SN, value); }
        [SugarColumn(ColumnName = "station_id")]
        public int 工位号 { get => _工位号; set => SetProperty(ref _工位号, value); }
        [SugarColumn(ColumnName = "station_in_time")]
        public DateTime 入站时间 { get => _入站时间; set => SetProperty(ref _入站时间, value); }
        [SugarColumn(ColumnName = "station_out_time")]
        public DateTime 出站时间 { get => _出站时间; set => SetProperty(ref _出站时间, value); }
        [SugarColumn(ColumnName = "freeze")]
        public string 冻结标志 { get => _冻结标志; set => SetProperty(ref _冻结标志, value); } 

    }
}
