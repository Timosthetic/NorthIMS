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
    [SugarTable("product_process_order")]
    public class product_process_order : NotifyPropertyChanged
    {
        private int _Id;
        private string _母件编码;
        private string _母件名称;
        private int _工序代码;
        private string _工序描述;
        private float _工序标准CT;

        private string _原材料编码;
        private string _原材料名称;
        private int _齐套数量;
        private DateTime _创建时间;
        private string _创建人员;
        private string _freeze;

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get => _Id; set => SetProperty(ref _Id, value); }
        [SugarColumn(ColumnName = "product_code")]
        public string 母件编码 { get => _母件编码; set => SetProperty(ref _母件编码, value); }
        [SugarColumn(ColumnName = "product_name")]
        public string 母件名称 { get => _母件名称; set => SetProperty(ref _母件名称, value); }
        [SugarColumn(ColumnName = "action_id")]
        public int 工序代码 { get => _工序代码; set => SetProperty(ref _工序代码, value); }
        [SugarColumn(ColumnName = "action_desc")]
        public string 工序描述 { get => _工序描述; set => SetProperty(ref _工序描述, value); }
        [SugarColumn(ColumnName = "action_ct")]
        public float 工序标准CT { get => _工序标准CT; set => SetProperty(ref _工序标准CT, value); }
        [SugarColumn(ColumnName = "material_code")]
        public string 原材料编码 { get => _原材料编码; set => SetProperty(ref _原材料编码, value); }
        [SugarColumn(ColumnName = "material_name")]
        public string 原材料名称 { get => _原材料名称; set => SetProperty(ref _原材料名称, value); }
        [SugarColumn(ColumnName = "material_full_count")]
        public int 齐套数量 { get => _齐套数量; set => SetProperty(ref _齐套数量, value); }
        [SugarColumn(ColumnName = "create_time")]
        public DateTime 创建时间 { get => _创建时间; set => SetProperty(ref _创建时间, value); } 
        [SugarColumn(ColumnName = "create_user")]
        public string 创建人员 { get => _创建人员; set => SetProperty(ref _创建人员, value); }
        public string freeze { get => _freeze; set => SetProperty(ref _freeze, value); }

    }
}
