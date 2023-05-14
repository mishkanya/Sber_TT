using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sber_WPFTT.Entities
{
    public class WordFinderData : INotifyPropertyChanged
    {
        private const string PROPERTY_NAME = "Text";

        public string Text
        {
            get => _text;
            set
            {
                if (value == _text)
                    return;

                _text = value;
                OnPropertyChanged(PROPERTY_NAME);
            }
        }
        private string _text;

        public void UpdateProperty() => OnPropertyChanged(PROPERTY_NAME);


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
