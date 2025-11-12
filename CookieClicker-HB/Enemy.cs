using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class Enemy
    {
        private string _name;
        private BigNumber _max_hit_points;
        private BigNumber _current_hit_points;
        private BigNumber _gold_reward;
        private bool _isDead;
        private EnemyIcon _icon;

        public string Name
        { get { return _name; } private set { _name = value; } }
        public BigNumber Max_hit_points
        { get { return _max_hit_points; } private set { _max_hit_points = value; } }
        public BigNumber Current_hit_points
        { get { return _current_hit_points; } private set { _current_hit_points = value; } }
        public BigNumber Gold_reward
        { get { return _gold_reward; } private set { _gold_reward = value; } }
        public bool IsDead
        { get { return _isDead; } private set { _isDead = value; } }
        public EnemyIcon Icon
        { get { return _icon; } private set { _icon = value; } }

        public Enemy(string name, BigNumber HP, BigNumber gold, EnemyIcon icon)
        {
            _name = name;
            _max_hit_points = HP;
            _current_hit_points = HP;
            _gold_reward = gold;
            _icon = icon;
        }

        public bool TakeDamage(BigNumber damage, out BigNumber reward)
        {
            reward = _gold_reward;
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

        private void Die()
        {

        }
    }
}
