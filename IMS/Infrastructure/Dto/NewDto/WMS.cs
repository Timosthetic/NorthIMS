using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public class WMS : Base
    {
        [SugarColumn(ColumnDescription = "库位编号 301-321")]
        public int Code { get; set; }

        [SugarColumn(ColumnDescription = "库位名称",IsNullable =true)]
        public string Name { get; set; }
        [SugarColumn(ColumnDescription = "层位置", IsNullable = true)]
        public string Pos_R { get; set; }

        [SugarColumn(ColumnDescription = "列位置", IsNullable = true)]
        public string Pos_C { get; set; }
    }
   
}
