using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("tray_map_label")]
    public class tray_map_label : NotifyPropertyChanged
    {
        private int _Id;
        private string _载具ID;
        private string _箱体标签;
        private string _主辅标志;
        private int _目的工位;
        private int _实时工位;
        private string _绑定人员;
        private DateTime _绑定时间;
        private string _解绑标志;

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "tray")]
        public string 载具ID { get => _载具ID; set => SetProperty(ref _载具ID, value); }
        [SugarColumn(ColumnName = "boxlabel")]
        public string 箱体标签 { get => _箱体标签; set => SetProperty(ref _箱体标签, value); }
        [SugarColumn(ColumnName = "ms_flag")]
        public string 主辅标志 { get => _主辅标志; set => SetProperty(ref _主辅标志, value); }
        [SugarColumn(ColumnName = "station_dest")]
        public int 目的工位 { get => _目的工位; set => SetProperty(ref _目的工位, value); }
        [SugarColumn(ColumnName = "station_realtime")]
        public int 实时工位 { get => _实时工位; set => SetProperty(ref _实时工位, value); }
        [SugarColumn(ColumnName = "create_user")]
        public string 绑定人员 { get => _绑定人员; set => SetProperty(ref _绑定人员, value); }
        [SugarColumn(ColumnName = "create_time")]
        public DateTime 绑定时间 { get => _绑定时间; set => SetProperty(ref _绑定时间, value); } 
        [SugarColumn(ColumnName = "freeze")]
        public string 解绑标志 { get => _解绑标志; set => SetProperty(ref _解绑标志, value); }//是解绑标志

    }
}
