using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    /// <summary>
    /// 工艺
    /// </summary>
    public class Io_prc_standard : Base
    {
       
        [SugarColumn(ColumnDescription = "物料编码")]
        public string Materiel { get; set; }



        [SugarColumn(ColumnDescription = "物料类型（子件类型）")]
        public string MtiClass { get; set; }


        [SugarColumn(ColumnDescription = "物料名称")]
        public string MtiName { get; set; }


        [SugarColumn(ColumnDescription = "工序齐套")]
        public int Atprule { get; set; }

        [SugarColumn(ColumnDescription = "工序ID")]
        public int PrcId { get; set; }
        /// <summary>
        /// 产品信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(PrcId))]//一对一
        public Io_prc_product Io_Prc_Product { get; set; }


    }
}
