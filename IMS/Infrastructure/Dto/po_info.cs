using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("po_info")]
    public class po_info : NotifyPropertyChanged
    {

        private int _Id;
        private string _项目号= DateTime.Now.ToString("yyyyMMddHHmm");
        private string _工单号;
        private int _工单数量;
        private string _图号;
        private string _产成品名称;
        private int _线上数量;
        private int _已完工数量;
        private DateTime? _创建时间;
        private string _创建人员;
        private DateTime? _开工日期;
        private DateTime? _计划完工日期;
        private string _实际完工日期;
        private string _工单状态="待上线";
        private float _合格率;
        private string _工位利用率;
        private string _流转路线;

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
        [SugarColumn(ColumnName = "online_count")]
        public int 线上数量 { get => _线上数量; set => SetProperty(ref _线上数量, value); }
        [SugarColumn(ColumnName = "finish_count")]
        public int 已完工数量 { get => _已完工数量; set => SetProperty(ref _已完工数量, value); }
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? 创建时间 { get => _创建时间; set => SetProperty(ref _创建时间, value); } 
        [SugarColumn(ColumnName = "create_user")]
        public string 创建人员 { get => _创建人员; set => SetProperty(ref _创建人员, value); }

        [SugarColumn(ColumnName = "start_time")]
        public DateTime? 开工日期 { get => _开工日期; set => SetProperty(ref _开工日期, value); }
        [SugarColumn(ColumnName = "planfinish_time")]
        public DateTime? 计划完工日期 { get => _计划完工日期; set => SetProperty(ref _计划完工日期, value); } 
        [SugarColumn(ColumnName = "actualfinish_time")]
        public string 实际完工日期 { get => _实际完工日期; 

            
            set => SetProperty(ref _实际完工日期, value); } 
        [SugarColumn(ColumnName = "po_status")]
        public string 工单状态 { get => _工单状态; set => SetProperty(ref _工单状态, value); }
        [SugarColumn(ColumnName = "ok_per")]
        public float 合格率 { get => _合格率; set => SetProperty(ref _合格率, value); }
        [SugarColumn(ColumnName = "station_avb_per")]
        public string 工位利用率 { get => _工位利用率; set => SetProperty(ref _工位利用率, value); }
        [SugarColumn(ColumnName = "Circulation_routes")]
        public string 流转路线 { get => _流转路线; set => SetProperty(ref _流转路线, value); }


        private string _Produktionsmenge;
        /// 生产数量
        /// </summary>
        [SugarColumn(IsIgnore =true)]
        public string Produktionsmenge
        {
            get { return _Produktionsmenge = $"{已完工数量}/{工单数量}"; }
            set { 
            
           
                    SetProperty(ref _Produktionsmenge, value);
               
            }
        }

    }
}
