using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GrayText
{
    public class TextCheck
    {
        private Data data;

        public TextCheck(Data data)
        {
            this.data = data;
        }

        public bool BadWord(string str)
        {
            if (data.blackListWords.Contains(str.ToLower()))
                return true;
            else
                return false;
        }

        public bool IsDelimiter(TextBox textBox)
        {
            char chr = textBox.ToString().LastOrDefault();
            if (Char.IsPunctuation(chr) || chr == ' ')
                return true;
            else
                return false;
        }
    }
}
