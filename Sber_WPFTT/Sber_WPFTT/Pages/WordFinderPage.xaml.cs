using Microsoft.Win32;
using Sber_WPFTT.Converters;
using Sber_WPFTT.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Sber_WPFTT.Pages
{
    public partial class WordFinderPage : Page
    {
        public WordFinderByCharsCount WordFinder { get; set; }
        public EmailFinder EmailsSearchPattern { get; set; }

        public WordFinderData InputText { get; set; }

        private ConverterSwitcher<string> _converterSwitcher = new ConverterSwitcher<string>();


        private UnicodeEncoding _uniEncoding = new UnicodeEncoding();

        public WordFinderPage()
        {
            WordFinder = new WordFinderByCharsCount();
            EmailsSearchPattern = new EmailFinder();
            InputText = new WordFinderData();

            InitializeComponent();
            InitializeConverterSwitcher();
            this.DataContext = this;

            WordFinder.CharsCount = 5;
            WordFinder.PropertyChanged += (o,e) => InputText.UpdateProperty();

            EmailsSearchPattern.PropertyChanged += (o, e) => InputText.UpdateProperty();
        }

        private void InitializeConverterSwitcher()
        {
            var tabs = tabControl.Items;

            Binding BuildBinding(IValueConverter converter)
            {
                var binding = new Binding("Text") { Converter = converter, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
                binding.Source = InputText;
                return binding;
            }

            _converterSwitcher.TryAddPair(((TabItem)tabs[0]).Header.ToString(), BuildBinding(WordFinder));

            _converterSwitcher.TryAddPair(((TabItem)tabs[1]).Header.ToString(), BuildBinding(EmailsSearchPattern));
        }

        private void SwitchConverter(string header)
        {
            if( _converterSwitcher.TryGetConverter(header, out var converter))
            {
                OutputTextBox.SetBinding(TextBox.TextProperty, converter);
            }
        }
        private void TabChanged(object sender, SelectionChangedEventArgs e)
        {
            SwitchConverter(((TabItem)e.AddedItems[0]).Header.ToString());
        }


        private async void ImportText(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;

                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    InputText.Text = await reader.ReadToEndAsync();
                }
            }

        }
        private async void ExportText(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    byte[] messageBytes = _uniEncoding.GetBytes(OutputTextBox.Text);
                    await myStream.WriteAsync(messageBytes, 0, messageBytes.Length);
                    myStream.Close();
                }
            }

        }

    }
}
