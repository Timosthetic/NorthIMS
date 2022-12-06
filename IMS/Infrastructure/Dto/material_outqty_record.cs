﻿using Infrastructure.Helper.Notify;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    [SugarTable("material_outqty_record")]
    public class material_outqty_record : NotifyPropertyChanged
    {
        private int _Id;
        private string _单号;
        private string _子件编码;
        private string _子件名称;
        private string _主辅标识;
        private string _ABC物料标志;
        private string _规格型号;
        private int _数量;
        private DateTime _操作时间;
        private string _操作人员;
        private string _入库批次号;
        private string _工单号;
        private int _工序代码;
        private string _工序描述;
        private int _单套数量;
        private string _产成品编码;
        private string _产成品名称;



        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "lot_no")]
        public string 单号 { get => _单号; set => SetProperty(ref _单号, value); }
        [SugarColumn(ColumnName = "material_code")]
        public string 子件编码 { get => _子件编码; set => SetProperty(ref _子件编码, value); }
        [SugarColumn(ColumnName = "material_name")]
        public string 子件名称 { get => _子件名称; set => SetProperty(ref _子件名称, value); }
        [SugarColumn(ColumnName = "ms_flag")]
        public string 主辅标识 { get => _主辅标识; set => SetProperty(ref _主辅标识, value); }
        [SugarColumn(ColumnName = "abc_flag")]
        public string ABC物料标志 { get => _ABC物料标志; set => SetProperty(ref _ABC物料标志, value); }
        [SugarColumn(ColumnName = "material_model")]
        public string 规格型号 { get => _规格型号; set => SetProperty(ref _规格型号, value); }
        [SugarColumn(ColumnName = "material_count")]
        public int 数量 { get => _数量; set => SetProperty(ref _数量, value); }

        [SugarColumn(ColumnName = "create_time")]
        public DateTime 操作时间 { get => _操作时间; set => SetProperty(ref _操作时间, value); }
        [SugarColumn(ColumnName = "create_user")]
        public string 操作人员 { get => _操作人员; set => SetProperty(ref _操作人员, value); }

        [SugarColumn(ColumnName = "batch_no")]
        public string 入库批次号 { get => _入库批次号; set => SetProperty(ref _入库批次号, value); }
        [SugarColumn(ColumnName = "po_no")]
        public string 工单号 { get => _工单号; set => SetProperty(ref _工单号, value); }
        [SugarColumn(ColumnName = "action_id")]
        public int 工序代码 { get => _工序代码; set => SetProperty(ref _工序代码, value); }
        [SugarColumn(ColumnName = "action_desc")]
        public string 工序描述 { get => _工序描述; set => SetProperty(ref _工序描述, value); }

        [SugarColumn(ColumnName = "single_full_count")]
        public int 单套数量 { get => _单套数量; set => SetProperty(ref _单套数量, value); }
        [SugarColumn(ColumnName = "product_code")]
        public string 产成品编码 { get => _产成品编码; set => SetProperty(ref _产成品编码, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 产成品名称 { get => _产成品名称; set => SetProperty(ref _产成品名称, value); }

    }
}
