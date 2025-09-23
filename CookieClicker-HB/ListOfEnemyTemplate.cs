using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace CookieClicker_HB
{
    class ListOfEnemyTemplate
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

            // надо будет на строне приёма сделать обработчиr для случаев когда нет такого имени
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

    }
}
