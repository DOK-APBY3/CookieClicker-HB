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
    class ListsManager
    {
        

        public List<EnemyTemplate> EnemyList1 { get; set; } = new List<EnemyTemplate>();
        public List<EnemyTemplate> EnemyList2 { get; set; } = new List<EnemyTemplate>();

        public List<UniversalListTemplate> allLists = new List<UniversalListTemplate>();

        public void SaveToJson(string path)
        {
            string json = JsonSerializer.Serialize(allLists, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public void LoadFromJson(string path)
        {
            string jsonString = File.ReadAllText(path);

            // Десериализуем в анонимный тип или используйте класс-контейнер
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                // Загружаем первый список (аналог strings1)
                if (root.TryGetProperty("List1", out JsonElement list1Element))
                {
                    EnemyList1.Clear();
                    foreach (JsonElement elem in list1Element.EnumerateArray())
                    {
                        EnemyTemplate enemy = ParseEnemyTemplate(elem);
                        EnemyList1.Add(enemy);
                    }
                }

                // Загружаем второй список (аналог strings2)
                if (root.TryGetProperty("List2", out JsonElement list2Element))
                {
                    EnemyList2.Clear();
                    foreach (JsonElement elem in list2Element.EnumerateArray())
                    {
                        EnemyTemplate enemy = ParseEnemyTemplate(elem);
                        EnemyList2.Add(enemy);
                    }
                }
            }
        }

        private EnemyTemplate ParseEnemyTemplate(JsonElement elem)
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
