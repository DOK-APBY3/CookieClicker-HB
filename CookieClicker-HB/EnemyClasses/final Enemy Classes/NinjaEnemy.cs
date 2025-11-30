using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class NinjaEnemy : Enemy
    {
        private double _uvoritingChanse;
        public Random rnd = new Random();
        public NinjaEnemy(string name, BigNumber HP, BigNumber gold, EnemyIcon icon, double uvoritingChanse) : base(name, HP, gold, icon)
        {
            if (uvoritingChanse <= 0.1) _uvoritingChanse = uvoritingChanse;
            else _uvoritingChanse = 0.1;
        }
        public virtual bool TakeDamage(BigNumber damage, out BigNumber reward)
        {
            reward = Gold_reward;

            double D100 = rnd.NextDouble();

            if (_uvoritingChanse >= D100)
            {
                return false;
            }
            else
            {
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
}
