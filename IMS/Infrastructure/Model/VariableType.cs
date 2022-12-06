using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Infrastructure.Model
{
    /// <summary>
    /// 变量类型
    /// </summary>
    public enum VariableType
    {
       
        XBool = 1,
      
        XShort = 2,
      
        XInt = 3,
       
        XFloate = 4,
      
        XString = 5,
       
        XBoolArray = 6,
      
        XShortArray = 7,
    }
  public enum Region
    {
        /// <summary>
        /// 公共区域
        /// </summary>
        PublicRegion = 1,
        /// <summary>
        /// 事件区域
        /// </summary>
        EventRegion=2,
    }

    public enum Path
    {
        /// <summary>
        /// 读取
        /// </summary>
        PlC_TO_EAP = 1,
        /// <summary>
        /// 写入
        /// </summary>
        EAP_TO_PLC=2,
    }
}
