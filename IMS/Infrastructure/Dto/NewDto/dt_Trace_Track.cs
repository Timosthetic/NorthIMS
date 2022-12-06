using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    /// <summary>
    /// 数据追踪追溯
    /// </summary>
    public class dt_Trace_Track:Base
    {
        [SugarColumn(ColumnDescription = "流水号",IsNullable =true)]
        public string Serial_num { get; set; }

        [SugarColumn(ColumnDescription = "工位ID", IsNullable = true)]
        public int Station { get; set; }


        private string _strStation;
        [SugarColumn( IsIgnore  = true)]
        public string StrStation
        {
            get { return _strStation=$"工位{string.Format("{0:D3}", Station).Remove(string.Format("{0:D3}", Station).Length-1)}"; }
            set { SetProperty(ref _strStation, value); }
        }


        [SugarColumn(ColumnDescription = "进站时间", IsNullable = true)]
        public DateTime? IN_Station { get; set; }

        [SugarColumn(ColumnDescription = "出站等待时间", IsNullable = true)]
        public DateTime? OutWait_Station { get; set; }


        [SugarColumn(ColumnDescription = "出站时间", IsNullable = true)]
        public DateTime? Out_Station { get; set; }
       
      
        private double _processing_Hours;
        [SugarColumn(ColumnDescription = "加工工时", IsNullable = true)]
        public double Processing_Hours
        {
            get { return _processing_Hours = double.Parse(_processing_Hours.ToString("0.000")); }
            set { SetProperty(ref _processing_Hours, value); }
        }


      
      

        private double _Wait_Hours;
        [SugarColumn(ColumnDescription = "等待工时", IsNullable = true)]
        public double Wait_Hours
        {
            get { return _Wait_Hours=double.Parse(_Wait_Hours.ToString("0.000")); }
            set { SetProperty(ref _Wait_Hours, value); }
        }


        [SugarColumn(ColumnDescription = "员工姓名", IsNullable = true)]
        public string StaffName { get; set; }

        [SugarColumn(ColumnDescription = "员工工号", IsNullable = true)]
        public string StaffNum { get; set; }

        [SugarColumn(ColumnDescription = "工单号", IsNullable = true)]
        public string WorkOrder { get; set; }

        /// <summary>
        /// 标牌流水码  产品唯一标识
        /// </summary>
        public string TagSerialnum { get; set; }




    }
}
