using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CookieClicker_HB
{
    public class Player : INotifyPropertyChanged
    {

        Random rnd = new Random();

        private int _lvl;// уровень пока хз чего                                                            0
        private int _swordLvl; // lvl mrcha                                                                 1
        private BigNumber _gold;// колво золота                                                             1
        private BigNumber _GoldRaised;//заработано золота (для статистики) (возможно в перспективе          1
        private BigNumber _damage;//урон                                     сделать статистику             1
        private double _damageMod;//модификатор для прокачки урона            в отделььной вкладке)         1
        private BigNumber _damageDealed;//количество нанесённого урона                                      0
        private BigNumber _swordupgradeCost;// стоймость прокачки меча                                      1
        private double _upgradeMod;//модификатор стоймости                                                  1
        private int _killedEnemy;//убитые враги                                                             0


        public int Lvl
        {
            get { return _lvl; }
            private set
            {
                _lvl = value;
                OnPropertyChanged("Lvl");
            }
        }
        public int SwordLvl
        {
            get { return _swordLvl; }
            private set
            {
                _swordLvl = value;
                OnPropertyChanged("SwordLvl");
            }
        }
        public BigNumber Gold
        {
            get { return _gold; }
            private set { _gold = value;
                OnPropertyChanged("Gold");
            }
        }
        public BigNumber GoldRaised
        {
            get { return _GoldRaised; }
            private set { _GoldRaised = value;
                OnPropertyChanged("GoldRaised");
            }
        }
        public BigNumber Damage
        {
            get { return _damage; }
            private set { _damage = value;
                OnPropertyChanged("Damage");
            }
        }
        public double DamageMod
        {
            get { return _damageMod; }
            private set { _damageMod = value;
                OnPropertyChanged("DamageMod");
            }
        }
        public BigNumber DamageDealed
        {
            get { return _damageDealed; }
            set { _damageDealed = value;
                OnPropertyChanged("DamageDealed");
            }
        }
        public BigNumber SwordUpgradeCost
        {
            get { return _swordupgradeCost; }
            private set {
                _swordupgradeCost = value;
                OnPropertyChanged("SwordUpgradeCost");
            }
        }
        public double UpgradeMod
        {
            get { return _upgradeMod; }
            private set { _upgradeMod = value;
                OnPropertyChanged("UpgradeMod");
            }
        }
        public int KilledEnemy
        {
            get { return _killedEnemy; }
            private set { _killedEnemy = value;
                OnPropertyChanged("KilledEnemy");
            }
        }

        public Player()
        {
            Lvl = 1;
            SwordLvl = 1;
            Gold = new BigNumber("0");
            GoldRaised = new BigNumber("0");
            Damage = new BigNumber("2");
            DamageMod = 1.25;
            DamageDealed = new BigNumber("0");
            SwordUpgradeCost = new BigNumber("15");
            UpgradeMod = 1.35;
            KilledEnemy = 0;

        }

        public void AddGold(BigNumber addedGold)
        {
            Gold = Gold + addedGold;
            GoldRaised = GoldRaised + addedGold;
        }

        public void removeGold(BigNumber removedGold)
        {
            if (TrySpendGold(removedGold))
            {
                Gold = Gold - removedGold;
            }
            else
            {
                
            }
        }

        public bool TryUpgradeSword()
        {
            if (TrySpendGold(SwordUpgradeCost))
            { UpgradeSword(); return true; }
            else return false;
        }

        public void UpgradeSword()
        {
            removeGold(SwordUpgradeCost);
            SwordLvl += 1;
            RecalculateStats();
        }

        public BigNumber DealDamage()
        {
            DamageDealed += Damage;
            return Damage;
        }

        public void EnemyKilled()
        {
            KilledEnemy += 1;
            Lvl += 1;
        }

        private void RecalculateStats()
        {
            SwordUpgradeCost = CalculateNexyUpgradeCoast();
            Damage = CalculateTotalDamage();
        }
        private BigNumber CalculateNexyUpgradeCoast()
        {
            double coastRandomComponent = (rnd.NextDouble() * (2 * UpgradeMod * (SwordLvl - 1))) - UpgradeMod * (SwordLvl - 1);
            
            BigNumber newSwordUpgradeCost = SwordUpgradeCost * (UpgradeMod * SwordLvl + coastRandomComponent); ;

            return newSwordUpgradeCost;
        }
        private BigNumber CalculateTotalDamage()
        {
            double damageRandomComponent = (rnd.NextDouble() * (2 * DamageMod * (SwordLvl - 1))) - DamageMod * (SwordLvl - 1);

            BigNumber newDamage = Damage * (DamageMod * SwordLvl + damageRandomComponent); ;

            return newDamage;
        }

        

        private bool TrySpendGold(BigNumber spendedGold)
        {
            if (_gold >= spendedGold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
