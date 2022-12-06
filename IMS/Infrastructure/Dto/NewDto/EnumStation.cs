using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public  enum EnumStation
    {
        ST01=1,
        ST02=2,
        ST03=3,
        ST04=4,
        ST05=5,
        ST06=6,
            
        ST07=7,
        ST08=8,
        ST09=9,
        ST10=10,
        ST11=11,
        ST12=12,

    }

    /// <summary>
    /// 工位集合
    /// </summary>
    public class StationEn
    {
        public StationEn(int iD, string stationName)
        {
            ID = iD;
            StationName = stationName;
        }

        public int ID { get; set; }

        public string StationName { get; set; }
    }

   public enum EnumRoamStation
    {
        ST1M=11,
        ST1S=12,
        ST2M = 21,
        ST2S = 22,
        ST3M = 31,
        ST3S = 32,
        ST4M = 41,
        ST4S = 42,
        ST5M = 51,
        ST5S = 52,
        ST6M = 61,
        ST6S = 62,
        ST7M = 71,
        ST7S = 72,
        ST8M = 81,
        ST8S = 82,
        ST9M = 91,
        ST9S = 92,
        ST10M = 101,
        ST10S = 102,
        ST11M = 111,
        ST11S = 112,
        ST12M = 121,
        ST12S = 122,
        ST14=141,
    }
}
