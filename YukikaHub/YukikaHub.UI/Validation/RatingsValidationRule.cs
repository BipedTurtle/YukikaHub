using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace YukikaHub.UI.Validation
{
    public class RatingsValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool parseSucceeded = int.TryParse(value.ToString(), out int rating);
            if (!parseSucceeded)
                return new ValidationResult(false, "Value is not integer; ratings should be an integer value");

            return
                rating switch {
                    (> 0 and <= 5) => new ValidationResult(true, null),
                    _ => new ValidationResult(false, "Ratings should be an integer between 0 and 5")};
        }
    }
}
