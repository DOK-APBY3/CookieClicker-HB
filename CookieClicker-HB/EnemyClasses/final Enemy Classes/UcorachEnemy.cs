using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    class UcorachEnemy : Enemy
    {
        private int _heigt;
        public UcorachEnemy(string name, BigNumber HP, BigNumber gold, EnemyIcon icon) : base(name, HP, gold, icon)
        {
            Heigt = 220;
        }


        public int Heigt
        { get { return _heigt; } protected set { 
                _heigt = value;
                OnPropertyChanged("Heigt");
            } }

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

                if (Heigt >= 60)
                {
                    Heigt -= 30;
                }
                Current_hit_points -= damage;
                return false;
            }
        }
    }
}
