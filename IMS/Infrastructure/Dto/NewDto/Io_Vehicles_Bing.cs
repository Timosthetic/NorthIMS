using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    public class Io_Vehicles_Bing:Base
    {
        [SugarColumn(ColumnDescription = "载具码")]
        public string vh_code { get; set; }
        [SugarColumn(ColumnDescription = "产品类型，母件编码",IsNullable =true)]
        public string pro_code { get; set; }


        [SugarColumn(ColumnDescription = "物料编码，主辅料编码", IsNullable = true)]
        public string material_code { get; set; }


        [SugarColumn(ColumnDescription = "流转工位，默认下料工位在内", IsNullable = true)]
        public string circulation_st { get; set; }

        [SugarColumn(ColumnDescription = "载具所在工位", IsNullable = true)]
        public string current_st { get; set; }

        [SugarColumn(ColumnDescription = "尚未流转工位", IsNullable = true)]
        public string await_st { get; set; }
        [SugarColumn(ColumnDescription = "产品流水码-主料，标记码-辅料", IsNullable = true)]
        public string serial_num { get; set; }
        [SugarColumn(ColumnDescription = "库位号码301-321", IsNullable = true)]
        public int wms_code { get; set; }
        [SugarColumn(ColumnDescription = "工单号", IsNullable = true)]
        public string workorder { get; set; }


        [SugarColumn(ColumnDescription = "不良品标记   1 ok  ，2 ng ,3 禁止标记")]
        public int ProMark { get; set; }

        /// <summary>
        /// 标牌流水码  产品唯一标识
        /// </summary>
        public string TagSerialnum { get; set; }

    }
}
