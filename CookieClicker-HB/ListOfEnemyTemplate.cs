using CookieClicker_HB.EnemyClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;


namespace CookieClicker_HB
{
    public class ListOfEnemyTemplate : UniversalListTemplate
    {

        [JsonInclude]
        public ObservableCollection<EnemyTemplate> enemies;

        Random rnd = new Random();

        private readonly ISaveList<List<EnemyTemplate>> _serializer = new JsonEnemySaver();


        public ListOfEnemyTemplate()
        {
            enemies = new ObservableCollection<EnemyTemplate>();
        }

        public void addEnemy(string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate)
        {
            enemies.Add(new CasualEnemeTemplate(name, iconName, iconSourse, groupe, baseLife, baseGold, lifeModifier, goldModifier, spawnRate));
        }

        public override void addListOfEnemys(List<EnemyTemplate> data)
        {

            foreach (EnemyTemplate enemy in data)
            {
                enemies.Add(new CasualEnemeTemplate(enemy.Name, enemy.IconName, enemy.IconSourse, enemy.Groupe, enemy.BaseLife, enemy.BaseGold, enemy.LifeModifier, enemy.GoldModifier, enemy.SpawnRate));
            }
        }

        public override List<EnemyTemplate> GetCurrentList()
        {
            return new List<EnemyTemplate>(enemies);
        }

        public void normalizeChances() 
        {
            double sum = 0;
            for (int i = 0; i < enemies.Count; i++)
                sum += enemies[i].SpawnRate;
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].SpawnRate /= sum;
        }

        public EnemyTemplate ReturnRandomEnemy() 
        {
            double chance = Math.Round(rnd.NextDouble(), 2);
            double sum = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                
            sum += enemies[i].SpawnRate;
                if (sum >= chance) return enemies[i];
            }
            return enemies[0];
        }


        public EnemyTemplate getEnemyByName(string name)
        {
            EnemyTemplate tmpEnemy = enemies.FirstOrDefault(enemy => enemy.Name == name);
            return tmpEnemy;

            // надо будет на строне приёма сделать обработчиr для случаев когда нет такого имени
        }
        public EnemyTemplate getEnemyByIndex(int index)
        {
            return enemies[index];
            // надо будет на строне приёма сделать обработчиr для случаев когда нет такого indexa
        }
        public void deleteEnemyByName(string name)
        {
            EnemyTemplate tmpEnemy = enemies.FirstOrDefault(enemy => enemy.Name == name);
            bool isEnemyDeleted = enemies.Remove(tmpEnemy);
            if (isEnemyDeleted)
            {
                MessageBox.Show($"Enemy named {name} Sucsessfull deleted YOOOOOOOO");
            }
            else
            {
                MessageBox.Show($"What's wrong, Emelya? There's no {name}");
            }
        }
        public void deleteEnemyByIndex(int index)
        {
            if (index < enemies.Count)
            {
                enemies.Remove(enemies[index]);
                MessageBox.Show($"Enemy № {index} Sucsessfull deleted YOOOOOOOO");
            }
            else
            {
                MessageBox.Show($"What's wrong, Emelya? Really? {index}? There aren't that many elements here to delete " +
                    $"something. Even a pack of Emelya crackers doesn't have that many elements.");
            }
        }

        public List<string> getListOfEnemyNames()
        {
            List<string> allNamesList = new List<string>();

            foreach (EnemyTemplate enemy in enemies)
            {
                allNamesList.Add(enemy.Name);
            }

            return allNamesList;
        }


        public override void saveToJson(string path)
        {
            string jsonString = JsonSerializer.Serialize(enemies); // сериализация списка (хз что это, наверное когда фильм режут на сериал чтобы больше денег нафармить)
            File.WriteAllText(path, jsonString); // сохранялка (джисус крайст, итс Json Борн)
        }


        


        public void loadFromJson(string result)
        {
            enemies = JsonSerializer.Deserialize<ObservableCollection<EnemyTemplate>>(result);
        }

    }
}
