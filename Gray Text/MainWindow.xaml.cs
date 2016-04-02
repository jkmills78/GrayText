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

namespace Gray_Text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextCheck textCheck;
        private StringBuilder stringBuilder;
        private string lastWord;


        public MainWindow()
        {
            InitializeComponent();

            textCheck = new TextCheck();
            lastWord = string.Empty;
            stringBuilder = new StringBuilder();
            textBox.Focus();
        }

        private void onTextChanged(object sender, TextChangedEventArgs e)
        {
            if (textCheck.IsDelimiter(textBox))
            {
                if (textCheck.BadWord(lastWord))
                {
                    e.Handled = true;
                    textBox.Text = stringBuilder.ToString();
                    textBox.CaretIndex = textBox.Text.Length;
                }
                else
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(textBox.Text);
                }

                lastWord = string.Empty;
            }
            else
            {
                lastWord += textBox.ToString().LastOrDefault();
            }
        }
    }
}
