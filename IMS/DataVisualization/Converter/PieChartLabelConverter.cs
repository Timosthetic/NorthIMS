using DataVisualization.Models;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataVisualization.Converter
{
    public class PieChartLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ChartAdornment pieAdornment = value as ChartAdornment;

            if (pieAdornment == null) return value;

            var model = pieAdornment.Item as DoughnutChartModel;

            if (model != null)
            {
                return String.Format(model.Category + " : " + pieAdornment.YData);
            }
            else
            {
                var list = pieAdornment.Item as List<object>;
                string labelData = "";

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i] as DoughnutChartModel;
                    labelData = labelData + String.Format(item.Category + " : " + item.Percentage);

                    if (i + 1 != list.Count)
                    {
                        labelData = labelData + Environment.NewLine;
                    }
                }

                return labelData;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
