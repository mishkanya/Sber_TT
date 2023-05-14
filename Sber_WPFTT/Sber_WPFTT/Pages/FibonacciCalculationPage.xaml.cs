using Sber_WPFTT.Entities;
using Sber_WPFTT.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace Sber_WPFTT.Pages
{
    public partial class FibonacciCalculationPage : Page
    {
        public FibonacciCalculatedData FibonacciData { get => _fibonacciData; set => _fibonacciData = value; }
        public FibonacciCalculatedData _fibonacciData = new FibonacciCalculatedData();

        FibonacciCalculationHelper _fibonacciCalculationHelper = new FibonacciCalculationHelper();
        public FibonacciCalculationPage()
        {
            InitializeComponent();
            this.DataContext = FibonacciData;
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(NumberEntry) == true)
                return;
            _fibonacciData = _fibonacciCalculationHelper.GetFibonacciCalculatedData(_fibonacciData);
        }
    }
}
