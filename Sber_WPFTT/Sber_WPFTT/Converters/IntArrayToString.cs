using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Sber_WPFTT.Converters
{
    [ValueConversion(typeof(int[]), typeof(String))]
    public class IntArrayToString : IValueConverter
    {
        private const string SPLIT_PATTERN = ", ";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int[] intArrayValue = (int[])value;
            return string.Join(", ", intArrayValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            int[] intArrayResult;
            try
            {
                intArrayResult = strValue.Split(new string[] { SPLIT_PATTERN }, StringSplitOptions.RemoveEmptyEntries).Select(t => int.Parse(t)).ToArray();
                return intArrayResult;
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
