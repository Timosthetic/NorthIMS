using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibExcel
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)] //规定特性类的用途（用于类或者字段）
    public class IsExport : Attribute
    {
        public bool IsExportData;
        public IsExport(bool bo)
        {
            IsExportData = bo;
        }
    }
}
