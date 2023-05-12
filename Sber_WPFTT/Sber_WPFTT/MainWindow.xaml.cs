using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sber_WPFTT.Pages;

namespace Sber_WPFTT
{
    public partial class MainWindow : Window
    {

        private List<Page> _pages = new List<Page>() 
        { 
            new FibonacciCalculationPage(), 
            new WordFinderPage() 
        };

        public MainWindow()
        {
            InitializeComponent();
            InitializePages();
        }

        private void InitializePages()
        {
            foreach (Page page in _pages)
            {
                var frame = new Frame();
                frame.Content = page;

                TabItem tabItem = new TabItem();
                tabItem.Content = frame;
                tabItem.Header = page.Title;
                this.TabControl.Items.Add(tabItem);
            }
        }
    }
}
