using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;


namespace Infrastructure.Bogus
{
    [SugarTable("po_info_bogus")]
    public class po_info_bogus 
    {

      

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [SugarColumn(ColumnName = "project_no")]
        public string 项目号 { get; set; }
        [SugarColumn(ColumnName = "po_no")]
        public string 工单号 { get; set; }
        [SugarColumn(ColumnName = "po_qty")]
        public int 工单数量 { get; set; }
        [SugarColumn(ColumnName = "product_code")]
        public string 图号 { get; set; }
        [SugarColumn(ColumnName = "product_name")]
        public string 产成品名称 { get; set; }
        [SugarColumn(ColumnName = "online_count")]
        public int 线上数量 { get; set; }
        [SugarColumn(ColumnName = "finish_count")]
        public int 已完工数量 { get; set; }
        [SugarColumn(ColumnName = "create_time")]
        public DateTime 创建时间 { get; set; }
        [SugarColumn(ColumnName = "create_user")]
        public string 创建人员 { get; set; }

        [SugarColumn(ColumnName = "start_time")]
        public DateTime 开工日期 { get; set; }
        [SugarColumn(ColumnName = "planfinish_time")]
        public DateTime 计划完工日期 { get; set; }
        [SugarColumn(ColumnName = "actualfinish_time")]
        public DateTime 实际完工日期 { get; set; }
        [SugarColumn(ColumnName = "po_status")]
        public string 工单状态 { get; set; }
        [SugarColumn(ColumnName = "ok_per")]
        public string 合格率 { get; set; }
        [SugarColumn(ColumnName = "station_avb_per")]
        public string 工位利用率 { get; set; }

    }
}
