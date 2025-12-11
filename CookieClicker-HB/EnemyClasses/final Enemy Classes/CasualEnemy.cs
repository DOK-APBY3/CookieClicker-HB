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
        public override void TakeDamage(BigNumber damage)
        {
            if (damage >= Current_hit_points)
            {
                Die();
            }
            else
            {
                Current_hit_points -= damage;
                Damaged();
            }
        }
    }
}
