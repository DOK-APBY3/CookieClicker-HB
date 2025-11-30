using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class HealingEnemyTemplate : EnemyTemplate
    {
        private double _healingChanse, _healingStrengh;

        public HealingEnemyTemplate(string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate, double healingChanse, double healingStrengh)
            : base(name, iconName, iconSourse, groupe, baseLife, baseGold, lifeModifier, goldModifier, spawnRate)
        {
            _healingChanse = healingChanse;
            _healingStrengh = healingStrengh;
        }

        public double HealingChanse
        {
            get { return _healingChanse; }
            set { _healingChanse = value; }
        }

        public double HealingStrange
        {
            get { return _healingStrengh; }
            set { _healingStrengh = value; }
        }
    }
}
