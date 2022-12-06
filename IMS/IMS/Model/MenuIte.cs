using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace IMS.Model
{
    public enum MenuIte
    {

        [Description("BOM管理")]
        Boom,
        [Description("人员管理")]
        Staff,
        [Description("工单管理")]
        WorkOrder,
        [Description("工艺管理")]
        Formula,
        //[Description("报警管理")]
        //Alarm,
        [Description("流程调度")]
        PlcEvent,
        [Description("数据管理")]
        CodeLable

    }
    public class EnumHelper
    {
        /// <summary>
        /// 获取枚举中的【Description】属性值
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            var objs = field.GetCustomAttribute(typeof(DescriptionAttribute));
            var descriptionAttribute = (DescriptionAttribute)objs;
            return descriptionAttribute.Description;
        }
    }
}
