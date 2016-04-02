using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gray_Text
{
    public class TextCheck
    {
        private List<string> blackList;

        public TextCheck()
        {
            blackList = new List<string>();

            // Initliaize black list
            blackList.Add("the");
            blackList.Add("and");
            blackList.Add("a");
            blackList.Add("of");
            blackList.Add("MySuperLongTextTestString");
        }

        public bool BadWord(string str)
        {
            if (blackList.Contains(str.ToLower()))
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
