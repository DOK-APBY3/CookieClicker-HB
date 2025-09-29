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
    class ListOfEnemyTemplate : UniversalListTemplate
    {
        List<EnemyTemplate> enemies;

        public ListOfEnemyTemplate()
        {
            enemies = new List<EnemyTemplate>();
        }

        public void addEnemy(string name, string iconName, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate)
        {
            EnemyTemplate tmpEnemy = new EnemyTemplate(name, iconName, baseLife, baseGold, lifeModifier, goldModifier, spawnRate);
            enemies.Add(tmpEnemy);
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



        public void loadFromJson(string path)
        {
            List<EnemyTemplate> t = JsonSerializer.Deserialize <List<EnemyTemplate>>(path);

        }

    }
}
