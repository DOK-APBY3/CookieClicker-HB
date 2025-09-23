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

        



    }
}
