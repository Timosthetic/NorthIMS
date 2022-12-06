using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    /// <summary>
    /// 齐套标准
    /// </summary>
    public class Io_pro_CompleteSet : Base
    {
        [SugarColumn(ColumnDescription = "产品ID")]
        public int Product { get; set; }

        [SugarColumn(ColumnDescription = "原材料类型")]
        public string mal_type { get; set; }


        [SugarColumn(ColumnDescription = "原材料编码")]
        public string mal_code { get; set; }

        [SugarColumn(ColumnDescription = "原材料名称")]
        public string mal_name { get; set; }

        [SugarColumn(ColumnDescription = "主辅标志")]
        public string mal_flag { get; set; }

        [SugarColumn(ColumnDescription = "齐套数量")]
        public int mal_num { get; set; }

        [SugarColumn(ColumnDescription = "剩余齐套数量")]
        public int mal_lastnum { get; set; }

        

    }
}
