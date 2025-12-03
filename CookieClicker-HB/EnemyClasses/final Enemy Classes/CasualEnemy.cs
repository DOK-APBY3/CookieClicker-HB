using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class CasualEnemy : Enemy
    {
        public CasualEnemy(string name, BigNumber HP, BigNumber gold, EnemyIcon icon) : base(name, HP, gold, icon)
        {
            
        }
        public override bool TakeDamage(BigNumber damage, out BigNumber reward)
        {
            reward = Gold_reward;
            if (damage >= Current_hit_points)
            {
                Die();
                return true;
            }
            else
            {
                Current_hit_points -= damage;
                return false;
            }
        }
    }
}
