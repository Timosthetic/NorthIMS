using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FeederProject.Models
{
    public enum MenuIte
    {

        [Description("上料管理")]
        Feeder,
       
        [Description("流程调度")]
        PlcEvent,


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
