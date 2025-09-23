using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class EnemyTemplate
    {
        private string _name, _iconName;
        private int _baseLife, _baseGold;
        private double _lifeModifier, _goldModifier, _spawnRate;

        public EnemyTemplate(string name, string iconName, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate)
        {
            _name = name;
            _iconName = iconName;
            _baseLife = baseLife;
            _baseGold = baseGold;
            _lifeModifier = lifeModifier;
            _goldModifier = goldModifier;
            _spawnRate = spawnRate;
        }
        // название врага
        public string Name
        { 
            get{ return _name; }
            set { _name = value;}
        }
        // название... иконки? АСЬ?
        public string IconName
        {
            get { return _iconName; }
            set { _iconName = value; }
        }
        // атрибуты для хпшек
        public int BaseLife
        {
            get { return _baseLife; }
            set { _baseLife = value; }
        }
        public double LifeModifier
        {
            get { return _lifeModifier; }
            set { _lifeModifier = value; }
        }
        // атрибуты для золота
        public int BaseGold
        {
            get { return _baseGold; }
            set { _baseGold = value; }
        }
        public double GoldModifier
        {
            get { return _goldModifier; }
            set { _goldModifier = value; }
        }
        //вероятность спавна
        public double SpawnRate
        {
            get { return _spawnRate; }
            set { _spawnRate = value; }
        }



    }
}
