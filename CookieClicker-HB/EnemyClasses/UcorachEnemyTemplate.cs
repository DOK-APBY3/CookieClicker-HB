using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class UcorachEnemyTemplate : EnemyTemplate
    {

        public UcorachEnemyTemplate(string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate)
            : base(name, iconName, iconSourse, groupe, baseLife, baseGold, lifeModifier, goldModifier, spawnRate)
        {

        }

    }
}
