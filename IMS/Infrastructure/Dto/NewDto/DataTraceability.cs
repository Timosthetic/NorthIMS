using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    /// <summary>
    /// 追踪追溯
    /// </summary>
    public class DataTraceability:Base
    {
        [SugarColumn(IsNullable =true)]
        /// <summary>
        /// 流水号
        /// </summary>
        public string  serial_num { get; set; }
        [SugarColumn(IsNullable = true)]
        /// <summary>
        /// 工单号
        /// </summary>
        public string work_order { get; set; }
        [SugarColumn(IsNullable = true)]
        /// <summary>
        /// 流转工位
        /// </summary>
        public string station { get; set; }


        [SugarColumn(IsNullable = true)]
        /// <summary>
        /// 母件编码
        /// </summary>
        public string procode { get; set; }

        [SugarColumn(IsNullable = true)]
        /// <summary>
        /// 母件名称
        /// </summary>
        public string proName{ get; set; }

        [SugarColumn(IsNullable = true)]
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode { get; set; }

        [SugarColumn(IsNullable = true)]
        /// <summary>
        /// 物料名称
        /// </summary>
        public string materialName{ get; set; }



        [SugarColumn(IsNullable = true)]
        /// <summary>
        /// 是否打印标记
        /// </summary>
        public bool IsCode { get; set; }

        [SugarColumn(IsIgnore = true)]
        public bool IsShipped { get; set; } = true;


        /// <summary>
        /// 标牌流水码  产品唯一标识
        /// </summary>
        public string TagSerialnum { get; set; }


        public DateTime CreatTime { get; set; }= DateTime.Now;
    }
}
