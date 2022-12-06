using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ReadWritePlc
{
    public class PlcEventGroup
    {
        public string Key { get; set; }

        public List<PlcEventExcel> Item { get; set; }
    }
}
