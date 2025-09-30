using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;


namespace CookieClicker_HB
{
    static class ListsManager
    {
        // Храним сразу сериализуемые данные
        private static Dictionary<string, UniversalListTemplate> allLists = new Dictionary<string, UniversalListTemplate>();

        public static void addToGL(string listName, UniversalListTemplate data)
        {
            allLists[listName] = data;
        }
         

        public static void SaveToJson()
        {
            Dictionary<string, List<EnemyTemplate>> dctWithAllLists = new Dictionary<string, List<EnemyTemplate>>();

            foreach (var item in allLists)
            {
                dctWithAllLists[item.Key] = item.Value.GetCurrentList();
            }

            FileManager.SaveToSelectedFile(dctWithAllLists);


        }


        public static void LoadFromJson(string path)
        {

        }

    }
}
