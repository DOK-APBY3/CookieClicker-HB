using CookieClicker_HB.EnemyClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace CookieClicker_HB
{
    public class ListOfEnemyTemplate : UniversalListTemplate
    {

        [JsonInclude]
        public ObservableCollection<EnemyTemplate> enemies { get; set; } = new ObservableCollection<EnemyTemplate>();

        Random rnd = new Random();

        private readonly ISaveList<List<EnemyTemplate>> _serializer = new JsonEnemySaver();

        


        public ListOfEnemyTemplate()
        {
            
        }

        public void addEnemy(string typeName, string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate, params object[] additionalArgs )
        {
            // Создаём врага через фабрику, передав ему все необходимые аргументы
            // Включая аргументы для уникальных свойств (например, armor для ArmoredEnemyTemplate)
            // Все аргументы после базовых передаются как additionalArgs
            var args = new object[] { name, iconName, iconSourse, groupe, baseLife, baseGold, lifeModifier, goldModifier, spawnRate }.Concat(additionalArgs).ToArray();
            EnemyTemplate newEnemy = EnemyZavod.CreateEnemyTemplate(typeName, args);
            enemies.Add(newEnemy);
        }

        public override void addListOfEnemys(List<EnemyTemplate> data)
        {

            foreach (EnemyTemplate enemy in data)
            {
                enemies.Add(enemy);
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
            List<EnemyTemplate> savableList = new List<EnemyTemplate>(enemies);
            _serializer.Save(savableList, path);
        }

        public void loadFromJson(string path)
        {
            
            List<EnemyTemplate> loadedList = _serializer.Load(path);

            enemies.Clear();
            foreach (var item in loadedList)
            {
                enemies.Add(item);
            }
        }


    }


    public class TypeNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "типа не ма";
            return value.GetType().Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

}
