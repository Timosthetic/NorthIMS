using System;
using System.Collections.Generic;
using System.Text;

namespace FeederProject.Models
{
    public class SimulationModel
    {

        public int Id { get; set; }
        

        private string title;
        /// <summary>
        /// 位置名称标记
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value;

                if (value.Contains("ST"))
                {
                   
                        background = "#546e7a";
                  
                   
                }
                else if (value.Contains("TF"))
                {
                  
                        background = "LightGray";
                   
                  
                }
                else if (value.Contains("BF"))
                {
                   
                        background = "#757575";
                 
                 
                }
                else if (value.Contains("DOWN"))
                {
                   
                        background = "#9c2b70";
                  
                   
                }

                else if (value.Contains("UP"))
                {
                   
                        background = "#cd4319";
                  
                   
                }
               
            }
        }



       
        private int tag;
        /// <summary>
        /// 占位标记   1 空闲   2 占位
        /// </summary>

        public int Tag
        {
            get { return tag; }
            set
            {
                tag = value;

                if (value == 2)
                {
                    background = "Green";
                }
                else
                {
                    if (Title.Contains("ST"))
                    {

                        background = "#546e7a";


                    }
                    else if (Title.Contains("TF"))
                    {

                        background = "LightGray";


                    }
                    else if (Title.Contains("BF"))
                    {

                        background = "#757575";


                    }
                    else if (Title.Contains("DOWN"))
                    {

                        background = "#9c2b70";


                    }

                    else if (Title.Contains("UP"))
                    {

                        background = "#cd4319";


                    }
                }
            }
        }


        /// <summary>
        /// 工位标识码
        /// </summary>
        public int STNum { get; set; }

        private string background = "Gray";
        /// <summary>
        /// 状态颜色
        /// </summary>
        /// 

        public string BackGround
        {
            get { return background; }
            set
            {
                background = value;

                //if (value == "Gray" || value == "Transparent")
                //{
                //    IsEnable = false;
                //}
                //else
                //{
                //    IsEnable = true;
                //}

            }
        }

        /// <summary>
        /// 是否可以启用
        /// </summary>
        public bool IsEnable { get; set; }


        public string serialnum { get; set; }


        /// <summary>
        /// 进站或出站标识
        /// </summary>
        public string InOut { get; set; }

    }   
}
