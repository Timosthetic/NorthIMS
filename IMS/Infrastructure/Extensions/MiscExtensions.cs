using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Extensions
{
    /// <summary>
    /// 获取集合中最新的 固定条数数据
    /// </summary>
    public static class MiscExtensions
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }
    }
}
