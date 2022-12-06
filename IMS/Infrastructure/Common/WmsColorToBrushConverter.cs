using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Infrastructure.Common
{
    public class WmsColorToBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueTemp = System.Convert.ToBoolean(value);
            return new SolidColorBrush(valueTemp ? Colors.Green : Colors.Gray);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
