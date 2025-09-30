using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace CookieClicker_HB
{
     static class FileManager
    {

        private static readonly string lastFilePathFile =  System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WpfBUZMAZ_lastFile.txt");
        private static string lastFilePath;

        static ListOfEnemyTemplate loader = new ListOfEnemyTemplate();

        


        private static void LastSavedFinder()
        {

            if (File.Exists(lastFilePathFile))
            {
                lastFilePath = File.ReadAllText(lastFilePathFile);
            }
        }
        private static void LastSavedLoader()
        {
            if (File.Exists(lastFilePath))
            {
                
                loader.loadFromJson(lastFilePath);
            }
        }

        public static void LoadFromSelectedFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Text documents (.json)|*.json";
            dlg.ShowDialog();
            string lb1 = dlg.FileName;

            loader.loadFromJson(lb1);
        }


        public static void SaveToSelectedFile(Dictionary<string, List<EnemyTemplate>> data)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Text documents (.json)|*.json";
            dlg.ShowDialog();
            string path = dlg.FileName;

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);

        }

        

    }
}
