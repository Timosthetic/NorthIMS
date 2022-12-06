using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.StyleControl
{
    public interface ICloseWindows
    {
        Action MinWindow { get; set; }

        Action MaxWindow { get; set; }
        Action NolWindow { get; set; }
        Action Close { get; set; }
        bool CanClose();
    }
}
