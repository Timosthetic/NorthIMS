using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Helper.Notify;
using SqlSugar;

namespace Infrastructure.Dto
{
    [SugarTable("material_qty_cur")]
    public class material_qty_cur : NotifyPropertyChanged
    {


        private int _Id;
        private string _子件编码;
        private string _子件名称;
        private string _主辅标识;
        private string _ABC物料标志;
        private string _规格型号;
        private int _数量;


        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }

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

    }
}
