using Infrastructure.Helper.Notify;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace Infrastructure.Dto
{
    [SugarTable("alarmrecord")]
    public class AlarmRecord : NotifyPropertyChanged
    {
        private int _Id;
        private string _报警信息;
        private string _报警工站名称;
        private DateTime _报警开始时间;
        private DateTime _报警结束时间;
        private int _报警持续时间;
        private string _故障类型;
        private DateTime _发生时间;
        
        private string _班次 ;



        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "woringName")]//数据库与实体不一样设置列名 
        public string 报警信息 { get => _报警信息; set => SetProperty(ref _报警信息, value); }


        [SugarColumn(ColumnName = "station")]
        public string 报警工站名称 { get => _报警工站名称; set => SetProperty(ref _报警工站名称, value); }

        [SugarColumn(ColumnName = "starttime")]
        public DateTime 报警开始时间 { get => _报警开始时间; set => SetProperty(ref _报警开始时间, value); }
        [SugarColumn(ColumnName = "endtime")]
        public DateTime 报警结束时间 { get => _报警结束时间; set => SetProperty(ref _报警结束时间, value); }



        [SugarColumn(ColumnName = "spantime")]
        public int 报警持续时间 { get => _报警持续时间; set => SetProperty(ref _报警持续时间, value); }


        [SugarColumn(ColumnName = "woringstate")]
        public string 故障类型 { get => _故障类型; set => SetProperty(ref _故障类型, value); }



        [SugarColumn(ColumnName = "time")]
        public DateTime 发生时间 { get => _发生时间; set => SetProperty(ref _发生时间, value); }


        [SugarColumn(ColumnName = "class")]
        public string 班次 { get => _班次; set => SetProperty(ref _班次, value); }

    }




}
