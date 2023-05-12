using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sber_WPFTT.Entities
{
    public class FibonacciCalculatedData : INotifyPropertyChanged
    {
        public FibonacciCalculatedData() { }

        public int TargetNumber
        {
            get => _targetNumber;
            set
            {
                if (value == _targetNumber)
                    return;

                _targetNumber = value;
                OnPropertyChanged("TargetNumber");
            }
        }
        private int _targetNumber;
        public int[] FibonacciSequence
        {
            get => _fibonacciSequence;
            set
            {
                if (value == _fibonacciSequence)
                    return;

                _fibonacciSequence = value;
                OnPropertyChanged("FibonacciSequence");
            }
        }

        private int[] _fibonacciSequence = new int[0];
        public int FibonacciSequenceSum
        {
            get => _fibonacciSequenceSum;
            set
            {
                if (value == _fibonacciSequenceSum)
                    return;

                _fibonacciSequenceSum = value;
                OnPropertyChanged("FibonacciSequenceSum");
            }
        }
        private int _fibonacciSequenceSum;



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
