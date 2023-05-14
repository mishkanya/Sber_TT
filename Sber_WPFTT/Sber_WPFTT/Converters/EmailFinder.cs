using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace Sber_WPFTT.Converters
{
    [ValueConversion(typeof(String), typeof(String))]
    public class EmailFinder : IValueConverter, INotifyPropertyChanged
    {
        private Regex _emailRegex = new Regex("([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z0-9_-]+)");
        private const string SEPARATOR = "; ";

        private const string PROPERTY_NAME = "SearchPattern";
        public string SearchPattern
        {
            get => _searchPattern;
            set
            {
                if (value == _searchPattern)
                    return;

                _searchPattern = value;
                OnPropertyChanged(PROPERTY_NAME);
            }
        }
        private string _searchPattern;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = (string)value;
            if (string.IsNullOrEmpty(stringValue))
                return null;

            var response = _emailRegex
                .Matches(stringValue)
                .Cast<Match>()
                .Select(t => t.Value);

            if (string.IsNullOrEmpty(SearchPattern) == false)
                response = response.Where(t => t.Contains(SearchPattern));

            return string.Join(SEPARATOR, response);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue; ;
        }


        public void UpdateProperty() => OnPropertyChanged(PROPERTY_NAME);
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}