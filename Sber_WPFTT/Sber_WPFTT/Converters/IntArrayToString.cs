using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Sber_WPFTT.Converters
{
    [ValueConversion(typeof(int[]), typeof(String))]
    public class IntArrayToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int[] stringResponse = (int[])value;
            return string.Join(", ", stringResponse);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            int[] resultIntArray;
            try
            {
                resultIntArray = strValue.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(t => int.Parse(t)).ToArray();
                return resultIntArray;
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
            
        }
    }
}
