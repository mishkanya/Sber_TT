using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace Sber_WPFTT.Converters
{
    [ValueConversion(typeof(String), typeof(String))]

    public class WordFinderByCharsCount : IValueConverter, INotifyPropertyChanged
    {
        public uint CharsCount
        {
            get => _charsCount;
            set
            {
                if (value == _charsCount)
                    return;

                _charsCount = value;
                OnPropertyChanged(PROPERTY_NAME);
            }
        }
        private uint _charsCount;
        private const string PROPERTY_NAME = "CharsCount";


        private char[] _ignoredChars = new char[] { '@', '-' };
        private string[] _splitePatterns = new string[] { Environment.NewLine, " " };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = (string)value;
            if (string.IsNullOrEmpty(stringValue))
                return null;

            var wordsArray = stringValue
                .Split(
                        _splitePatterns,
                        StringSplitOptions.RemoveEmptyEntries
                    )
                .Select(
                    t => new string(t.ToCharArray().Where(tt => char.IsLetterOrDigit(tt) || _ignoredChars.Contains(tt)).ToArray()))
                .Where(t => t.Length >= CharsCount)
                .Where(t => string.IsNullOrEmpty(t) == false);
            return string.Join(" ", wordsArray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
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
