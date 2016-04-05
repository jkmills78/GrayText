using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Shapes;
using GrayText;

namespace GrayText
{
    /// <summary>
    /// Interaction logic for BlackListWords.xaml
    /// </summary>
    public partial class BlackListWords : Window
    {
        private Data data;

        public BlackListWords(Data data)
        {
            InitializeComponent();

            this.data = data;
            listView.ItemsSource = data.blackListWords;
        }

        private void onRemoveClick(object sender, RoutedEventArgs e)
        {
            data.blackListWords.RemoveAt(listView.SelectedIndex);
            data.DeleteWord();
        }

        private void onAddClick(object sender, RoutedEventArgs e)
        {
            if (wordToAdd.Text != string.Empty)
            {
                data.blackListWords.Add(wordToAdd.Text);
                data.AddWord(wordToAdd.Text);
                wordToAdd.Text = string.Empty;
            }
        }
    }
}
