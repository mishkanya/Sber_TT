using System;
using System.Globalization;
using System.Windows.Controls;

namespace Sber_WPFTT.Validators
{
    public class IntegerRangeValidation : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intValue = 0;
            string stringValue = (string)value;

            try
            {
                if (stringValue.Length > 0)
                    intValue = Int32.Parse(stringValue);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if ((intValue < Min) || (intValue > Max))
            {
                return new ValidationResult(false,
                  $"Please enter an age in the range: {Min}-{Max}.");
            }
            return ValidationResult.ValidResult;
        }
    }
}