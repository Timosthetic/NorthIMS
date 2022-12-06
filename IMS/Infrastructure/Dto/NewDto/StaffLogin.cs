using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.NewDto
{
    /// <summary>
    /// 每个工位登录的员工统计
    /// </summary>
    public class StaffLogin:Base
    {
        [SugarColumn(ColumnDescription = "工位", IsNullable = true)]
        public string Station { get; set; }
        [SugarColumn(ColumnDescription = "工位标识", IsNullable = true)]

        public int StationID { get; set; }
        [SugarColumn(ColumnDescription = "员工姓名", IsNullable = true)]

        public string StaffName { get; set; }
        [SugarColumn(ColumnDescription = "员工工号", IsNullable = true)]

        public string StaffNum { get; set; }

        [SugarColumn(ColumnDescription = "产品名称", IsNullable = true)]

        public string ProductName { get; set; }

        [SugarColumn(ColumnDescription = "工序名称", IsNullable = true)]

        public string ProcessName { get; set; }

     

        private bool _ProcessStatus;
        [SugarColumn(ColumnDescription = "工序状态")]
        public bool ProcessStatus
        {
            get { return _ProcessStatus; }
            set
            {
                _ProcessStatus = value;

                if (value)
                {
                    procstr = "装配中";
                }
                else
                {
                    procstr = "闲置中";
                }

            }
        }


        [SugarColumn(ColumnDescription = "装配效率", IsNullable = true)]

        public double Efficiency { get; set; }

       


        private bool _IsLogin;
        [SugarColumn(ColumnDescription = "是否登录")]

        public bool IsLogin
        {
            get { return _IsLogin; }


            set
            {
                _IsLogin = value;

                if (value)
                {
                    Loginstr = "登录";
                }
                else
                {
                    Loginstr = "离线";
                }

            }
        }



        [SugarColumn(IsIgnore =true)]
        public string Loginstr { get; set; }
        [SugarColumn(IsIgnore = true)]

        public string procstr { get; set; }

        public string STName { get; set; }
    }
}
