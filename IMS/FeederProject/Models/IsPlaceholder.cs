using System;
using System.Collections.Generic;
using System.Text;

namespace FeederProject.Models
{
    /// <summary>
    /// 是否占位
    /// </summary>
    public class IsPlaceholder
    {
        /// <summary>
        /// 主料工位ID
        /// </summary>
        public string StationID { get; set; }
        /// <summary>
        /// 目的工位是否占位
        /// </summary>
        public bool Isph { get; set; }=false;   
    }
}
