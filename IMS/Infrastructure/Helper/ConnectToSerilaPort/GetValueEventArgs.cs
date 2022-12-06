using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helper.ConnectToSerilaPort
{
    public class GetValueEventArgs:EventArgs
    {
        /// <summary>
        /// 电测数据
        /// </summary>
        public string SerialData { get; set; }
    }
}
