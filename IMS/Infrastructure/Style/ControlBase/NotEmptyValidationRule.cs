using System.Globalization;
using System.Windows.Controls;
namespace Infrastructure.Style.ControlBase
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "未选中合法选项.")
                : ValidationResult.ValidResult;
        }
    }
}
