using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public class kanBan_WorkingHours:Base
    {
        [SugarColumn(ColumnDescription = "工位名称", IsNullable = true)]
        public string Station { get; set; }
        [SugarColumn(ColumnDescription = "工位ID", IsNullable = true)]
        public int StId { get; set; }

        [SugarColumn(ColumnDescription = "加工工时", IsNullable = true)]
        public double Processing_Hours { get; set; }


        [SugarColumn(ColumnDescription = "等待工时", IsNullable = true)]
        public double Wait_Hours { get; set; }


        public string STName { get; set; }
    }
}
