using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class ArmoredEnemy : Enemy
    {
        private int _armor;

        public ArmoredEnemy(string name, BigNumber HP, BigNumber gold, EnemyIcon icon, int armor) : base(name, HP, gold, icon)
        {
            if (armor <= 90)
            {
                _armor = armor;
            }
            else
            {
                _armor = 90;
            }
        }
        public virtual bool TakeDamage(BigNumber damage, out BigNumber reward)
        {
            reward = Gold_reward;

            BigNumber currentDamage = damage - (damage * (_armor)/100);

            if (currentDamage >= Current_hit_points)
            {
                Die();
                return true;
            }
            else
            {
                Current_hit_points -= currentDamage;
                return false;
            }
        }
    }
}
