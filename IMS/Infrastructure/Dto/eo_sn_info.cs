using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;


namespace Infrastructure.Dto
{
    [SugarTable("eo_sn_info")]
    public class eo_sn_info : NotifyPropertyChanged
    {


        private int _Id;
        private string _year;
        private int _sn_in;
        private int _sn_out;


        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        public string year { get => _year; set => SetProperty(ref _year, value); }
        public int sn_in { get => _sn_in; set => SetProperty(ref _sn_in, value); }
        public int sn_out { get => _sn_out; set => SetProperty(ref _sn_out, value); } 

    }
}
