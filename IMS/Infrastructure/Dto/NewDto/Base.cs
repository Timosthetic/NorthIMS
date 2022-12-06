using Infrastructure.Helper.Notify;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public class Base : NotifyPropertyChanged
    {

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, IsOnlyIgnoreInsert = true)]
        public int ID { get; set; }

    }
}
