using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class CasualEnemeTemplate : EnemyTemplate
    {
        public CasualEnemeTemplate(string name, string iconName, string iconSourse, string groupe, int baseLife, int baseGold, double lifeModifier, double goldModifier, double spawnRate) : base
            (name, iconName, iconSourse, groupe, baseLife, baseGold, lifeModifier, goldModifier, spawnRate)
        {
            
        }
    }
}
