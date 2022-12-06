using Infrastructure.Helper.Notify;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    /// <summary>
    /// 工序ColumnDescription
    /// </summary>
    public class Io_prc_product: Base
    {
      


        [SugarColumn(ColumnDescription = "工序ID")]
        public int  Node { get; set; }
        [SugarColumn(ColumnDescription = "工序名称")]
        public string NodeName { get; set; }

        [SugarColumn(ColumnDescription = "工序描述")]
        public string Description { get; set; }


       
       
        private string _esop;
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(ColumnDescription = "Sop", IsNullable = true)]
        public string Esop
        {
            get { return _esop; }
            set { SetProperty(ref _esop, value); }
        }


        [SugarColumn(ColumnDescription = "标准CT")]
        public float CT { get; set; }

        [SugarColumn(ColumnDescription = "创建用户")]
        public string User_create { get; set; }

        [SugarColumn(ColumnDescription = "匹配工位")]
        public EnumStation Station { get; set; }
        /// <summary>
        /// 工艺齐套
        /// </summary>
        [Navigate(NavigateType.OneToMany,nameof(Io_prc_standard.PrcId))]
        public List<Io_prc_standard> StanardList { get; set; }



        [SugarColumn(ColumnDescription = "产品ID")]
        public int Product { get; set; }
        /// <summary>
        /// 产品信息
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Product))]//一对一
        public Io_pro_details Pro_Detail { get; set; }
    }
}
