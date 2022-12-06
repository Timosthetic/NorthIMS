using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ReadWritePlc
{
    public  class BaseGroup
    {
        public string Key { get; set; }
        public List<CsvBasicInFoModel> Value { get; set; }
    }
}
