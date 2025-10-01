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

        public static void LoadFromSelectedFile(ListOfEnemyTemplate sourse)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Text documents (.json)|*.json";
            dlg.ShowDialog();
            string path = dlg.FileName;

            string jsonString = File.ReadAllText(path);

            
            sourse.loadFromJson(jsonString);
            
        }

        public static void UniLoadFromSelectedFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Text documents (.json)|*.json";
            dlg.ShowDialog();
            string path = dlg.FileName;

            string jsonString = File.ReadAllText(path);

            Dictionary<string, List<EnemyTemplate>> loadingDct = JsonSerializer.Deserialize<Dictionary<string, List<EnemyTemplate>>>(jsonString);

            ListsManager.LoadFromJson(loadingDct);
        }


        public static void SaveToSelectedFile(ListOfEnemyTemplate sourse)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Text documents (.json)|*.json";
            dlg.ShowDialog();
            string path = dlg.FileName;

            sourse.saveToJson(path);

        }

        public static void UniSaveToSelectedFile(Dictionary<string, List<EnemyTemplate>> data)
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
