using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace GrayText
{
    public class Data
    {
        private StreamReader fin;
        private StreamWriter fout;
        private string appDataFolder;

        public ObservableCollection<string> blackListWords { get; set; }

        public Data()
        {
            appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            blackListWords = new ObservableCollection<string>();
            if (!File.Exists(appDataFolder + @"\GrayText\words.dic"))
            {
                fout = new StreamWriter(appDataFolder + @"\GrayText\words.dic");
                fout.Close();
            }
            else
                UpdateBlackList();
        }

        public void UpdateBlackList()
        {
            if (new FileInfo(appDataFolder + @"\GrayText\words.dic").Length > 0)
            {
                string line;
                fin = new StreamReader(appDataFolder + @"\GrayText\words.dic");
                while ((line = fin.ReadLine()) != null)
                {
                    blackListWords.Add(line.ToString().Trim().ToLower());
                }
                fin.Close();
            }
        }

        public void DeleteWord()
        {
            fout = new StreamWriter(appDataFolder + @"\GrayText\words.dic", false);
            foreach (var word in blackListWords)
            {
                fout.WriteLine(word);
            }
            fout.Close();
        }

        public void AddWord(string str)
        {
            fout = new StreamWriter(appDataFolder + @"\GrayText\words.dic", true);
            fout.WriteLine(str);
            fout.Close();
        }

        public void SaveFile(string str)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text|*.txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, str);
        }
    }
}
