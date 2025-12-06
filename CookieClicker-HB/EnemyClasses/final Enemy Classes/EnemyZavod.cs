using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CookieClicker_HB

{
    public class ZavodEventArgs : EventArgs
    {
        //ссылка на визуальное представление собираемого объекта
        public Enemy _newenemy;
        public ZavodEventArgs(Enemy newenemy)
        {
            this._newenemy = newenemy;
        }
    }

    public delegate void ZavodEvent(ZavodEventArgs e);


    public static class EnemyZavod
    {

        private static Random rnd = new Random();

        private static int heroeLvl = 2;
        static int killsToHarder = 10;
        private static Player Gamer;

        public static void AddPlayer(Player player)
            {
            Gamer = player;
            }



        public static IEnemy CreateEnemy(string typeName, params object[] args)
        {
            // Находим тип по названию
            var type = Assembly.GetExecutingAssembly().GetTypes() .FirstOrDefault(t => t.Name == typeName);
            // Создаем объект с передачей параметров в конструктор
            return (IEnemy)Activator.CreateInstance(type, args);
        }
        public static EnemyTemplate CreateEnemyTemplate(string typeName, params object[] args)
        {
            // Находим тип по названию
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);
            // Создаем объект с передачей параметров в конструктор
            return (EnemyTemplate)Activator.CreateInstance(type, args);
        }

        public static void CreateEnemyFromTemplate(EnemyTemplate template)
        {
            
            string templateTypeName = template.GetType().Name;

            string enemyTypeName = TemplateToEnemyType(templateTypeName);

            var enemyType = Assembly.GetExecutingAssembly().GetTypes()
                               .FirstOrDefault(t => t.Name == enemyTypeName && typeof(Enemy).IsAssignableFrom(t));


            // Создаём аргументы для конструктора Enemy
            // Пример для HealingEnemy: (string name, BigNumber HP, BigNumber gold, EnemyIcon icon, double healingChanse, double healingStrengh)
            // Нужно извлечь их из template
            object[] args = CreateArgsForEnemyConstructor(template);

            Enemy newEnemy = (Enemy)Activator.CreateInstance(enemyType, args);

            EnemyAdded?.Invoke(new ZavodEventArgs(newEnemy));

        }


        public static event ZavodEvent EnemyAdded;

        // Метод для сопоставления имён
        private static string TemplateToEnemyType(string templateTypeName)
        {
                Dictionary<string, string> templateToEnemyMap = new Dictionary<string, string>
            {
                { "HealingEnemyTemplate", "HealingEnemy" },
                { "ArmoredEnemyTemplaye", "ArmoredEnemy" },
                { "CasualEnemeTemplate", "CasualEnemy" },
                { "NinjaEnemyTemplate", "NinjaEnemy" },
                { "UcorachEnemyTemplate", "UcorachEnemy" },
            };

            return templateToEnemyMap.GetValueOrDefault(templateTypeName);
        }
        private static object[] CreateArgsForEnemyConstructor(EnemyTemplate template)
        {
            if (killsToHarder == 0)
            {
                heroeLvl = Gamer.Lvl;
                killsToHarder = 10;

            }
            else killsToHarder--;

            
            BigNumber baseHP = new BigNumber(template.BaseLife.ToString());
            double lifeMod = template.LifeModifier;
            double HPRandomComponent = (rnd.NextDouble() * (2 * lifeMod * (heroeLvl - 2))) - lifeMod * (heroeLvl - 2);
            BigNumber newHP = baseHP * (lifeMod * (heroeLvl - 1) + HPRandomComponent);

            BigNumber baseGold = new BigNumber(template.BaseGold.ToString());
            double goldMod = template.GoldModifier; 
            double GoldRandomComponent = (rnd.NextDouble() * (2 * goldMod * (heroeLvl - 2))) - goldMod * (heroeLvl - 2);
            double addedGold = (goldMod * (heroeLvl - 1) * (heroeLvl - 1) + GoldRandomComponent);
            BigNumber newGold = baseGold * addedGold;


            EnemyIcon icon = new EnemyIcon(template.IconName, template.IconSourse);

            
            if (template is HealingEnemyTemplate healingTemplate)
            {
                return new object[] { template.Name, newHP, newGold, icon, healingTemplate.HealingChanse, healingTemplate.HealingStrange };
            }
            else if (template is ArmoredEnemyTemplaye armoredTemplate)
            {
                return new object[] { template.Name, newHP, newGold, icon, armoredTemplate.Armor };
            }
            else if (template is NinjaEnemyTemplate ninjaTemplate)
            {
                return new object[] { template.Name, newHP, newGold, icon, ninjaTemplate.UvoritingChanse };
            }


            return new object[] { template.Name, newHP, newGold, icon };
        }
    }
}
