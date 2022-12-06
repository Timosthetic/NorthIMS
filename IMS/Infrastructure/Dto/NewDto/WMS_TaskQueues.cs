using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public class WMS_TaskQueues:Base
    {
        [SugarColumn(ColumnDescription = "库位编号")]
        public int wms_code { get; set; }

        [SugarColumn(ColumnDescription = "任务状态  1，正在处理中  0 待处理")]
        public int task_status { get; set; }
        [SugarColumn(ColumnDescription = "工位编号",IsNullable = true)]
        public string st_num { get; set; }
        [SugarColumn(ColumnDescription ="主料 1 ，辅料 2  下线 3" )]
        public int isexists_MS { get; set; }
        [SugarColumn(ColumnDescription = "唯一标识码，主料是工单号，辅料是流水号")]
        public string tag_order { get; set; }

    }
}
