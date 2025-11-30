using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class ArmoredEnemyTemplaye : EnemyTemplate
    {
        private int _armor;

        public ArmoredEnemyTemplaye(string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate, int armor)
            : base(name, iconName, iconSourse, groupe, baseLife, baseGold, lifeModifier, goldModifier, spawnRate)
        {
            
            _armor = armor;
        }

        public int Armor
        { get { return _armor; } set { _armor = value; } }
    }
}
