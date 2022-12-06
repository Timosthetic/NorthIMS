using Infrastructure.Helper.Notify;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Dto
{
    [SugarTable("station_status_realtime")]
    public class station_status_realtime : NotifyPropertyChanged
    {

        private int _Id;
        private int _工位号;
        private string _工单号;
        private string _员工号;
        private string _员工姓名;
        private string _工位状态;
        private int _工序代码;
        private string _工序描述;
        private string _产成品名称;
        private string _产成品编码;
        private float _装配工时;
        private float _等待工时;
        private float _装配效率;
        private int _辅料托盘数量;
        private string _标志;




        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "station_id")]
        public int 工位号 { get => _工位号; set => SetProperty(ref _工位号, value); }
        [SugarColumn(ColumnName = "po_no")]
        public string 工单号 { get => _工单号; set => SetProperty(ref _工单号, value); }
        [SugarColumn(ColumnName = "op_no")]
        public string 员工号 { get => _员工号; set => SetProperty(ref _员工号, value); }
        [SugarColumn(ColumnName = "op_name")]
        public string 员工姓名 { get => _员工姓名; set => SetProperty(ref _员工姓名, value); }
        [SugarColumn(ColumnName = "status")]
        public string 工位状态 { get => _工位状态; set => SetProperty(ref _工位状态, value); }
        [SugarColumn(ColumnName = "action_id")]
        public int 工序代码 { get => _工序代码; set => SetProperty(ref _工序代码, value); }
        [SugarColumn(ColumnName = "action_desc")]
        public string 工序描述 { get => _工序描述; set => SetProperty(ref _工序描述, value); }

        [SugarColumn(ColumnName = "product_name")]
        public string 产成品名称 { get => _产成品名称; set => SetProperty(ref _产成品名称, value); }
        [SugarColumn(ColumnName = "product_code")]
        public string 产成品编码 { get => _产成品编码; set => SetProperty(ref _产成品编码, value); }

        [SugarColumn(ColumnName = "assemble_time")]
        public float 装配工时 { get => _装配工时; set => SetProperty(ref _装配工时, value); }

        [SugarColumn(ColumnName = "wait_time")]
        public float 等待工时 { get => _等待工时; set => SetProperty(ref _等待工时, value); }
        [SugarColumn(ColumnName = "assemble_per")]
        public float 装配效率 { get => _装配效率; set => SetProperty(ref _装配效率, value); }
        [SugarColumn(ColumnName = "slavetray_material_cout")]
        public int 辅料托盘数量 { get => _辅料托盘数量; set => SetProperty(ref _辅料托盘数量, value); }
        [SugarColumn(ColumnName = "freeze")]
        public string 标志 { get => _标志; set => SetProperty(ref _标志, value); }//是否可出去

    }
}
