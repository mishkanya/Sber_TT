using Sber_WPFTT.Entities;
using Sber_WPFTT.Helpers;
using Sber_WPFTT.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
