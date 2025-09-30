using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows;

namespace CookieClicker_HB
{
     class FileManager
    {

        private readonly string lastFilePathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WpfBUZMAZ_lastFile.txt");
        private string lastFilePath;

        ListOfEnemyTemplate loader = new ListOfEnemyTemplate();

        public FileManager()
        {

        }


        private void LastSavedFinder()
        {

            if (File.Exists(lastFilePathFile))
            {
                lastFilePath = File.ReadAllText(lastFilePathFile);
            }
        }
        private void LastSavedLoader()
        {
            if (File.Exists(lastFilePath))
            {
                
                loader.loadFromJson(lastFilePath);
            }
        }

        private void LoadFromSelectedFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Text documents (.json)|*.json";
            dlg.ShowDialog();
            string lb1 = dlg.FileName;

            loader.loadFromJson(lb1);
        }


        public void SaveToSelectedFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Text documents (.json)|*.json";
            dlg.ShowDialog();
            string lb1 = dlg.FileName;

            ListsManager.SaveToJson(lb1);

            //sourse.saveToJson(lb1);
        }

        

    }
}
