using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    /// <summary>
    /// 产品详情（工艺，流转路线总表）
    /// </summary>
    public class Io_pro_details : Base
    {

        [SugarColumn(ColumnDescription = "产品型号编码")]
        public string proCode { get; set; }







        [SugarColumn(ColumnDescription = "产品型号名称")]
        public string proName { get; set; }



        [SugarColumn(ColumnDescription = "是否配置工序")]
        public bool isPrc { get; set; }
       

        /// <summary>
        /// 工序
        /// </summary>
        [Navigate(NavigateType.OneToMany,nameof(Io_prc_product.Product))]
        public List<Io_prc_product> prcList { get; set; }


        /// <summary>
        ///产品齐套
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Io_pro_CompleteSet> pro_cps_List { get; set; }
    }
}
