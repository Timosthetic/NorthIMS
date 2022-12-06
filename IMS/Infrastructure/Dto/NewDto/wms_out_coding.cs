using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{

    /// <summary>
    /// 出库打印
    /// </summary>
    public class wms_out_coding
    {

        [SugarColumn(ColumnDescription = "主/辅料编码", IsNullable =true)]
        /// <summary>
        /// 主/辅料编码
        /// </summary>
        public string Material_code { get; set; }
        [SugarColumn(ColumnDescription = "主/辅料名称", IsNullable = true)]
        /// <summary>
        /// 主/辅料名称
        /// </summary>
        public string Material_name { get; set; }
      
        [SugarColumn(ColumnDescription = "当前工单剩余未打印的数量", IsNullable = true)]
        /// <summary>
        /// 当前工单剩余未打印的数量
        /// </summary>
        public int LastNum { get; set; }
        [SugarColumn(ColumnDescription = "齐套数量", IsNullable = true)]
        /// <summary>
        /// 齐套数量
        /// </summary>
        public int mal_num { get; set; }

        [SugarColumn(ColumnDescription = "打印标签时间", IsNullable = true)]
        public string CodeTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


        [SugarColumn(ColumnDescription = "操作人员姓名", IsNullable = true)]
        public string MasterName { get; set; }

        [SugarColumn(ColumnDescription = "是否打印标记", IsNullable = true)]
        public bool IsCode { get; set; }


        [SugarColumn(ColumnDescription = "主辅标识", IsNullable = true)]
        public string MS{ get; set; }

        [SugarColumn(IsIgnore =true)]
        public bool IsShipped { get; set; }

        [SugarColumn(ColumnDescription = "工单ID", IsNullable = true)]
        public int OrderID { get; set; }

        /// <summary>
        /// 产品信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(OrderID))]//一对一
        public po_info po_info { get; set; }




    }
}
