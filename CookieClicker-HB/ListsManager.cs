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
        
        

        //public List<UniversalListTemplate> allLists = new List<UniversalListTemplate>();

        public static Dictionary<string, UniversalListTemplate> allLists = new Dictionary<string, UniversalListTemplate>();

        public static void addToGL(string listName, UniversalListTemplate data)//add to Global List
        {
            allLists.Add(listName, data);
        }

        


        public static void SaveToJson(string path)
        {
            string json = JsonSerializer.Serialize(allLists, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);

        }

        public static void LoadFromJson(string path)
        {


            List<UniversalListTemplate> t = JsonSerializer.Deserialize<List<UniversalListTemplate>>(path);
        }

        private static EnemyTemplate ParseEnemyTemplate(JsonElement elem)
        {
            string name = elem.GetProperty("Name").GetString();
            string iconName = elem.GetProperty("IconName").GetString();
            int baseLife = elem.GetProperty("BaseLife").GetInt32();
            int baseGold = elem.GetProperty("BaseGold").GetInt32();
            double lifeMod = elem.GetProperty("LifeModifier").GetDouble();
            double goldMod = elem.GetProperty("GoldModifier").GetDouble();
            double spawnRate = elem.GetProperty("SpawnRate").GetDouble();

            return new EnemyTemplate(name, iconName, baseLife, baseGold, lifeMod, goldMod, spawnRate);
        }
    }
}
