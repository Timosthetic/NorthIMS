using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public class DeviceStopDate:Base
    {
        [SugarColumn(ColumnDescription = "设备运行开始时间",IsNullable =true)]
        public DateTime? RunTime { get; set; }
        [SugarColumn(ColumnDescription = "设备停止开始时间", IsNullable = true)]
        public DateTime? StopTime { get; set; } 

        [SugarColumn(ColumnDescription = "设备停止时长", IsNullable = true)]
        public double StopHours { get; set; }
    }
}
