using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class HealingEnemy : Enemy
    {
        private double _healingChanse, _healingStrengh;

        public Random rnd = new Random();

        public HealingEnemy(string name, BigNumber HP, BigNumber gold, EnemyIcon icon, double healingChanse, double healingStrengh) : base(name, HP, gold, icon)
        {
            if (healingChanse <= 0.1)  _healingChanse = healingChanse;
            else _healingChanse = 0.1;

            if (healingStrengh <= 5) _healingStrengh = healingStrengh;
            else _healingStrengh = 5;

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
                double D100 = rnd.NextDouble();

                if (_healingChanse >= D100)
                {
                    Current_hit_points += damage * _healingStrengh;
                }
                Current_hit_points -= damage;
                return false;
            }
        }
    }
}
