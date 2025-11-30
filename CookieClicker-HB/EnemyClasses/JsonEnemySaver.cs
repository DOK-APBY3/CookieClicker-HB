using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace CookieClicker_HB.EnemyClasses
{
    class JsonEnemySaver : ISaveList<List<EnemyTemplate>>
    {

        private readonly JsonSerializerOptions _options;
        public JsonEnemySaver()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                //Установка конвертера противников для реализации полиморфизма
                Converters = { new EnemyTemplateConverter() }
            };
        }

        public List<EnemyTemplate> Load(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                //Десериализация с определение класса противника
                return JsonSerializer.Deserialize<List<EnemyTemplate>>(json, _options) ?? new
               List<EnemyTemplate>();
            }
            return new List<EnemyTemplate>();
        }
        //Реализация функции сохранения
        public void Save(List<EnemyTemplate> data, string path)
        {
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(path, json);
        }


    }
}
