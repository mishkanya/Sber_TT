using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace Sber_WPFTT.Converters
{
    [ValueConversion(typeof(String), typeof(String))]

    public class WordFinderByCharsCount : IValueConverter, INotifyPropertyChanged
    {
        private const string PROPERTY_NAME = "CharsCount";
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

        private char[] _ignoredChars = new char[] {'@', '-'};
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringResponse = (string)value;
            if (string.IsNullOrEmpty(stringResponse))
                return null;

            var wordsArray = stringResponse
                .Split(
                        new string[] { Environment.NewLine, " " },
                        StringSplitOptions.None
                    )
                .Select(
                    t => new string(
                        t.ToCharArray().
                        Where(tt => char.IsLetterOrDigit(tt) || _ignoredChars.Contains(tt))
                        .ToArray()))
                .Where(t=> t.Length >= CharsCount)
                .Where(t=> string.IsNullOrEmpty(t) == false);
            return string.Join(" ", wordsArray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
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
