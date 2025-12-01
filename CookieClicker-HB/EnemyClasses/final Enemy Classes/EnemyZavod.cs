using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class EnemyZavod
    {
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

    }
}
