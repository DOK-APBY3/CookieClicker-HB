using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
