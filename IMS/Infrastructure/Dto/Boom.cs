using Infrastructure.Helper.Notify;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto
{
    [SugarTable("boom_info")]
    public class Boom : NotifyPropertyChanged
    {
        private int _Id	;
 private string _母件编码	;
 private string _母件名称	;
 private string _子件类别	;
 private string _子件编码	;
 private string _子件名称	;
 private string _主辅标识	;
 private string _ABC物料标志	;
 private string _规格型号	;
 private int _数量	;
 private string _版本	;
 private DateTime _创建时间=DateTime.Now	;
 private string _创建人员	;
 private DateTime _更新时间 = DateTime.Now;
        private string _更新人员	;
 private string _冻结标志	;


        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "product_code")]//数据库与实体不一样设置列名 
        public string 母件编码 { get => _母件编码; set => SetProperty(ref _母件编码, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 母件名称 { get => _母件名称; set => SetProperty(ref _母件名称, value); }
        [SugarColumn(ColumnName = "material_type")]
        public string 子件类别 { get => _子件类别; set => SetProperty(ref _子件类别, value); }
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
        [SugarColumn(ColumnName = "ver")]
        public string 版本 { get => _版本; set => SetProperty(ref _版本, value); }
        [SugarColumn(ColumnName = "create_time")]
        public DateTime 创建时间 { get => _创建时间; set => SetProperty(ref _创建时间, value); } 
        [SugarColumn(ColumnName = "create_user")]
        public string 创建人员 { get => _创建人员; set => SetProperty(ref _创建人员, value); }
        [SugarColumn(ColumnName = "update_time")]
        public DateTime 更新时间 { get => _更新时间; set => SetProperty(ref _更新时间, value); } 
        [SugarColumn(ColumnName = "update_user")]
        public string 更新人员 { get => _更新人员; set => SetProperty(ref _更新人员, value); } 
        [SugarColumn(ColumnName = "freeze")]
        public string 冻结标志 { get => _冻结标志; set => SetProperty(ref _冻结标志, value); } 
    }
}
