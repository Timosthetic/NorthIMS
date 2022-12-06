using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Extensions
{
    public static class ConvertToNumber
    {
        /// <summary>
        /// 获取字符串中的数字 
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>数字</returns>
        public static decimal GetNumber(string str)
        {
            decimal result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                //str = Regex.Replace(str, @"[^/d./d]", "");
                str = Regex.Replace(str, @"[^\d.\d]", "");
                if (!string.IsNullOrEmpty(str))
                {
                    // 如果是数字，则转换为decimal类型
                    if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                    {
                        result = decimal.Parse(str);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取字符串中的数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>数字</returns>
        public static int GetNumberInt(string str)
        {
            int result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d.\d]", "");
                if (!string.IsNullOrEmpty(str))
                {
                    if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                    {
                        result = int.Parse(str);
                    }
                }
                // 如果是数字，则转换为decimal类型
              
            }
            return result;
        }
    }
}
