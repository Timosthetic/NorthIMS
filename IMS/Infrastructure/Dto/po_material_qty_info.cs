using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("po_material_qty_info")]
    public class po_material_qty_info : NotifyPropertyChanged
    {

        private int _Id;
        private string _项目号;
        private string _工单号;
        private int _工单数量;
        private string _图号;
        private string _产成品名称;
        private string _原材料编码;
        private string _原材料名称;
        private string _主辅标志;
        private int _工位;
        private int _原材料齐套数量;
        private int _已领数量;
        private int _已上线数量;
        private int _标签已打原料数量;
        private int _标签已打数量;
        private DateTime _创建时间;
        private string _创建人员;
        private DateTime _开工日期;
        private DateTime _计划完工日期;
        private DateTime _实际完工日期;
        private string _工单状态;



        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "project_no")]
        public string 项目号 { get => _项目号; set => SetProperty(ref _项目号, value); }
        [SugarColumn(ColumnName = "po_no")]
        public string 工单号 { get => _工单号; set => SetProperty(ref _工单号, value); }
        [SugarColumn(ColumnName = "po_qty")]
        public int 工单数量 { get => _工单数量; set => SetProperty(ref _工单数量, value); }
        [SugarColumn(ColumnName = "product_code")]
        public string 图号 { get => _图号; set => SetProperty(ref _图号, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 产成品名称 { get => _产成品名称; set => SetProperty(ref _产成品名称, value); }
        [SugarColumn(ColumnName = "material_code")]
        public string 原材料编码 { get => _原材料编码; set => SetProperty(ref _原材料编码, value); }
        [SugarColumn(ColumnName = "material_name")]
        public string 原材料名称 { get => _原材料名称; set => SetProperty(ref _原材料名称, value); }
        [SugarColumn(ColumnName = "ms_flag")]
        public string 主辅标志 { get => _主辅标志; set => SetProperty(ref _主辅标志, value); }
        //[SugarColumn(ColumnName = "abc_flag")]
        //public string ABC物料标志 { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "station_id")]
        public int 工位 { get => _工位; set => SetProperty(ref _工位, value); }
        [SugarColumn(ColumnName = "material_full_count")]
        public int 原材料齐套数量 { get => _原材料齐套数量; set => SetProperty(ref _原材料齐套数量, value); }
        [SugarColumn(ColumnName = "material_picked_count")]
        public int 已领数量 { get => _已领数量; set => SetProperty(ref _已领数量, value); } 
        [SugarColumn(ColumnName = "material_online_count")]
        public int 已上线数量 { get => _已上线数量; set => SetProperty(ref _已上线数量, value); }
        public int 标签已打原料数量 { get => _标签已打原料数量; set => SetProperty(ref _标签已打原料数量, value); } 
        [SugarColumn(ColumnName = "material_label_count")]
        public int 标签已打数量 { get => _标签已打数量; set => SetProperty(ref _标签已打数量, value); } 


        [SugarColumn(ColumnName = "create_time")]
        public DateTime 创建时间 { get => _创建时间; set => SetProperty(ref _创建时间, value); } 
        public string 创建人员 { get => _创建人员; set => SetProperty(ref _创建人员, value); }

        [SugarColumn(ColumnName = "start_time")]
        public DateTime 开工日期 { get => _开工日期; set => SetProperty(ref _开工日期, value); } 
        [SugarColumn(ColumnName = "planfinish_time")]
        public DateTime 计划完工日期 { get => _计划完工日期; set => SetProperty(ref _计划完工日期, value); } 
        [SugarColumn(ColumnName = "actualfinish_time")]
        public DateTime 实际完工日期 { get => _实际完工日期; set => SetProperty(ref _实际完工日期, value); } 
        [SugarColumn(ColumnName = "po_status")]
        public string 工单状态 { get => _工单状态; set => SetProperty(ref _工单状态, value); }

    }
}
