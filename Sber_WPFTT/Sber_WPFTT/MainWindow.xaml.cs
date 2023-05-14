using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
