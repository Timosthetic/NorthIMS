using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("material_entryqty_record")]
    public class material_entryqty_record : NotifyPropertyChanged
    {


        private int _Id;
        private string _单号;
        private string _子件编码;
        private string _子件名称;
        private string _主辅标识;
        private string _ABC物料标志;
        private string _规格型号;
        private int _总数量;
        private int _已领数量;
        private int _剩余数量;
        private DateTime _操作时间;
        private string _操作人员;
        private string _批次号;
        private string _note;

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "lot_no")]
        public string 单号{ get => _单号; set => SetProperty(ref _单号, value); }
        [SugarColumn(ColumnName = "material_code")]
        public string 子件编码{ get => _子件编码; set => SetProperty(ref _子件编码, value); }
        [SugarColumn(ColumnName = "material_name")]
        public string 子件名称{ get => _子件名称; set => SetProperty(ref _子件名称, value); }
        [SugarColumn(ColumnName = "ms_flag")]
        public string 主辅标识{ get => _主辅标识; set => SetProperty(ref _主辅标识, value); }
        [SugarColumn(ColumnName = "abc_flag")]
        public string ABC物料标志{ get => _ABC物料标志; set => SetProperty(ref _ABC物料标志, value); }
        [SugarColumn(ColumnName = "material_model")]
        public string 规格型号{ get => _规格型号; set => SetProperty(ref _规格型号, value); }
        [SugarColumn(ColumnName = "material_count")]
        public int 总数量{ get => _总数量; set => SetProperty(ref _总数量, value); }
        [SugarColumn(ColumnName = "material_out_count")]
        public int 已领数量{ get => _已领数量; set => SetProperty(ref _已领数量, value); }
        [SugarColumn(ColumnName = "material_left_count")]
        public int 剩余数量{ get => _剩余数量; set => SetProperty(ref _剩余数量, value); }
        [SugarColumn(ColumnName = "create_time")]
        public DateTime 操作时间{ get => _操作时间; set => SetProperty(ref _操作时间, value); } 
        [SugarColumn(ColumnName = "create_user")]
        public string 操作人员{ get => _操作人员; set => SetProperty(ref _操作人员, value); }

        [SugarColumn(ColumnName = "batch_no")]
        public string 批次号{ get => _批次号; set => SetProperty(ref _批次号, value); }
        public string note{ get => _note; set => SetProperty(ref _note, value); }

    }
}
