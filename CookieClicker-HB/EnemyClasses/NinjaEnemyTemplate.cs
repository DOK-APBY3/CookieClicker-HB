using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class NinjaEnemyTemplate : EnemyTemplate
    {

        private double _uvoritingChanse;
        public NinjaEnemyTemplate(string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate)
            : base(name, iconName, iconSourse, groupe, baseLife, baseGold, lifeModifier, goldModifier, spawnRate)
        {
            double uvoritingChanse = 0;
            _uvoritingChanse = uvoritingChanse;
        }
        public double UvoritingChanse
        {
            get { return _uvoritingChanse; }
            set { _uvoritingChanse = value; }
        }
    }
}
