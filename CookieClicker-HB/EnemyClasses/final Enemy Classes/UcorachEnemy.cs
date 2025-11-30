using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class UcorachEnemy : Enemy
    {
        public UcorachEnemy(string name, BigNumber HP, BigNumber gold, EnemyIcon icon) : base(name, HP, gold, icon)
        {

        }
        public virtual bool TakeDamage(BigNumber damage, out BigNumber reward)
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
