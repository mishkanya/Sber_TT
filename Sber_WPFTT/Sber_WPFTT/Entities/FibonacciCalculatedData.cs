using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sber_WPFTT.Entities
{
    public class FibonacciCalculatedData : INotifyPropertyChanged
    {

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
        private int _fibonacciSequenceSum;

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
        private int[] _fibonacciSequence = new int[0];

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
