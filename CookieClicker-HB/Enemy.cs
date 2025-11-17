using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class Enemy : INotifyPropertyChanged
    {
        private string _name;
        private BigNumber _max_hit_points;
        private BigNumber _current_hit_points;
        private BigNumber _gold_reward;
        private bool _isDead;
        private EnemyIcon _icon;
 
        public string Name
        { get { return _name; } private set { _name = value; OnPropertyChanged("Name"); } }
        public BigNumber Max_hit_points
        { get { return _max_hit_points; } private set { _max_hit_points = value; OnPropertyChanged("Max_hit_points"); } }
        public BigNumber Current_hit_points
        { get { return _current_hit_points; } private set { _current_hit_points = value; OnPropertyChanged("Current_hit_points"); } }
        public BigNumber Gold_reward
        { get { return _gold_reward; } private set { _gold_reward = value; OnPropertyChanged("Gold_reward"); } }
        public bool IsDead
        { get { return _isDead; } private set { _isDead = value; OnPropertyChanged("IsDead"); } }
        public EnemyIcon Icon
        { get { return _icon; } private set { _icon = value; OnPropertyChanged("Icon"); } }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
