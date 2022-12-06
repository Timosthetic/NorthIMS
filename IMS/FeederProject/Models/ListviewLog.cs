using System;
using System.Collections.Generic;
using System.Text;

namespace FeederProject.Models
{
    public class ListviewLog
    {
        public ListviewLog(string logTxt)
        {

            Station=
            LogTxt = logTxt;
            DateTime1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public ListviewLog(string logTxt, string station) 
        {
            LogTxt = logTxt;
            Station = station;
            DateTime1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string DateTime1 { get; set; } 
        public string LogTxt { get; set; }

        public string Station { get; set; }
    }
}
