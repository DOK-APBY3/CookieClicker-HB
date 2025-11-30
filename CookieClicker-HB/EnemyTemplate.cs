using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public abstract class EnemyTemplate
    {
        private string _name, _iconName, _groupe, _iconSourse;
        private int _baseLife, _baseGold;
        private double _lifeModifier, _goldModifier, _spawnRate;

        public EnemyTemplate(string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate)
        {
            _name = name;
            _iconName = iconName;
            _groupe = groupe;
            _baseLife = baseLife;
            _baseGold = baseGold;
            _lifeModifier = lifeModifier;
            _goldModifier = goldModifier;
            _spawnRate = spawnRate;
            IconSourse = iconSourse;
        }

        [JsonInclude]// атрибуты нужны чтобы сохранять в json, ставим их тут чтобы не было проблем из-за приватности полей
        public string Name // название врага
        { 
            get{ return _name; }
            set { _name = value;}
        }

        [JsonInclude]// чисто теоретически можно это всё удалить тк будет работать и без
        public string IconName // название иконки
        {
            get { return _iconName; }
            set { _iconName = value; }
        }

        [JsonInclude]
        public string IconSourse // путь иконки
        {
            get { return _iconSourse; }
            set { _iconSourse = value; }
        }

        [JsonInclude]
        public string Groupe
        {
            get{ return _groupe; }
            set { _groupe = value;}
        }

        // атрибуты для хпшек
        [JsonInclude]
        public int BaseLife
        {
            get { return _baseLife; }
            set { _baseLife = value; }
        }
        [JsonInclude]
        public double LifeModifier
        {
            get { return _lifeModifier; }
            set { _lifeModifier = value; }
        }

        // атрибуты для золота
        [JsonInclude]
        public int BaseGold
        {
            get { return _baseGold; }
            set { _baseGold = value; }
        }
        [JsonInclude]
        public double GoldModifier
        {
            get { return _goldModifier; }
            set { _goldModifier = value; }
        }

        //вероятность спавна
        [JsonInclude]
        public double SpawnRate
        {
            get { return _spawnRate; }
            set { _spawnRate = value; }
        }



    }
}
