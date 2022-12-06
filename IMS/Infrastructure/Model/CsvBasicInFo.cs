using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;


namespace Infrastructure.Model
{
  public   class CsvBasicInFo:ClassMap<CsvBasicInFoModel>
    {
        public CsvBasicInFo()
        {
            Map(m => m.Id).Name(Constants.Id);
            Map(m => m.RequestTagName).Name(Constants.RequestTagName);
            Map(m => m.ResponseTagName).Name(Constants.ResponseTagName);
            Map(m => m.VariableType).Name(Constants.VariableType);
            Map(m => m.Address).Name(Constants.Address);
            Map(m => m.length).Name(Constants.length);
            Map(m => m.EventGroup).Name(Constants.EventGroup);
            Map(m => m.Mark).Name(Constants.Mark);
        }
    }
     static class Constants
    {
            public const string Id = "ID";
            public const string RequestTagName = "Read";
            public const string ResponseTagName = "Write";
            public const string VariableType = "DataType";
            public const string Address = "Address";
            public const string length = "Length";
            public const string EventGroup = "Group";
            public const string Mark = "Mark";
    }
    public  class CsvBasicInFoModel
    {
        [Name(Constants.Id)]
        public string Id { get; set; } 
        [Name(Constants.RequestTagName)]
        public string RequestTagName { get; set; } 
        [Name(Constants.ResponseTagName)]
        public string ResponseTagName { get; set; } 
        [Name(Constants.VariableType)]
        public string VariableType { get; set; }
        [Name(Constants.Address)]
        public string Address { get; set; } 
        [Name(Constants.length)]
        public string length { get; set; } 
        [Name(Constants.EventGroup)]
        public string EventGroup { get; set; }
        [Name(Constants.Mark)]
        public string Mark { get; set; } = "详细介绍地址作用";
    }
}
