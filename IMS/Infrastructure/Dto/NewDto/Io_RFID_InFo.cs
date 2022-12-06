using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public class Io_RFID_InFo:Base
    {

        [SugarColumn(ColumnDescription = "工位ID")]
        public string Station { get; set; }
        [SugarColumn(ColumnDescription = "RFID_IP")]
        public string IpAddress { get; set; }


        [SugarColumn(ColumnDescription = "RFID_Port")]
        public int Port { get; set; }
        [SugarColumn(ColumnDescription = "工位标识")]
        public int StCode { get; set; }
    }
}
