using System;
using System.Collections.Generic;
using System.Text;

namespace FeederProject.Models
{
    public class RealTimeWMS
    {
        public int Id { get; set; }
        // [SugarColumn(ColumnDescription = "载具码")]
        public string vh_code { get; set; }
       // [SugarColumn(ColumnDescription = "产品类型，母件编码", IsNullable = true)]
        public string pro_code { get; set; }


      //  [SugarColumn(ColumnDescription = "物料编码，主辅料编码", IsNullable = true)]
        public string material_code { get; set; }


      //  [SugarColumn(ColumnDescription = "流转工位，默认下料工位在内", IsNullable = true)]
        public string circulation_st { get; set; }

        public string Station { get; set; }


        public string ProName { get; set; }


        // [SugarColumn(ColumnDescription = "产品流水码-主料，标记码-辅料", IsNullable = true)]
        public string serial_num { get; set; }
       // [SugarColumn(ColumnDescription = "库位号码301-321", IsNullable = true)]
        public int? wms_code { get; set; }
       // [SugarColumn(ColumnDescription = "工单号", IsNullable = true)]
        public string workorder { get; set; }


       
        private string background = "Gray";
        /// <summary>
        /// 状态颜色
        /// </summary>
        /// 

        public string BackGround
        {
            get { return background; }
            set { background = value;
            
            if(value=="Gray"||value== "Transparent")
                {
                    IsEnable = false;
                }
                else
                {
                    IsEnable = true;
                }
            
            }
        }

        /// <summary>
        /// 是否可以启用
        /// </summary>
        public bool IsEnable { get; set; }

    }
}
