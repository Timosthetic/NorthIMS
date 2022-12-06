using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class ContainExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
