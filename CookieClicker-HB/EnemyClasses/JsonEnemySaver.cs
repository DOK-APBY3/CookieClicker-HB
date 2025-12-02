using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

    class JsonPlayerSaver : ISaveList<Player>
    {
        private readonly JsonSerializerOptions options;
        public JsonPlayerSaver()
        {
            options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new BigNumberJsonConverter() }
            };
        }


        public Player Load(string path)
        {
            string result = File.ReadAllText(path);

            Player player =  JsonSerializer.Deserialize<Player>(result, options);

            return player;
        }
        //Реализация функции сохранения
        public void Save(Player data, string path)
        {
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }


    }
}
