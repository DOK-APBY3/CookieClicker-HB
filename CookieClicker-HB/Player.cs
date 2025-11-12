using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CookieClicker_HB
{
    class Player
    {

        private int _lvl;// уровень пока хз чего
        private BigNumber _gold;// колво золота
        private BigNumber _GoldRaised;//заработано золота (для статистики) (возможно в перспективе
        private BigNumber _damage;//урон                                     сделать статистику 
        private double _damageMod;//модификатор для прокачки урона            в отделььной вкладке)
        private BigNumber _damageDealed;//количество нанесённого урона
        private BigNumber _upgradeCost;// стоймость прокачки меча
        private double _upgradeMod;//модификатор стоймости
        private int _killedEnemy;//убитые враги 
        

        public int Lvl
        {
            get { return _lvl; }
            private set { _lvl = value; }
        }
        public BigNumber Gold
        {
            get { return _gold; }
            private set { _gold = value; }
        }
        public BigNumber GoldRaised
        {
            get { return _GoldRaised; }
            private set { _GoldRaised = value; }
        }
        public BigNumber Damage
        {
            get { return _damage; }
            private set { _damage = value; }
        }
        public double DamageMod
        {
            get { return _damageMod; }
            private set { _damageMod = value; }
        }
        public BigNumber DamageDealed
        {
            get { return _damageDealed; }
            private set { _damageDealed = value; }
        }
        public BigNumber UpgradeCost
        {
            get { return _upgradeCost; }
            private set { _upgradeCost = value; }
        }
        public double UpgradeMod
        {
            get { return _upgradeMod; }
            private set { _upgradeMod = value; }
        }
        public int KilledEnemy
        {
            get { return _killedEnemy; }
            set { _killedEnemy = value; }
        }

        public Player()
        {

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
                MessageBox.Show("Извините, вы НИЩИЙ!", "Вак вак вак");
            }
        }

        public bool TryUpgrade()
        {
            if (TrySpendGold(UpgradeCost)) return true;
            else return false;
        }

        public BigNumber DealDamage()
        {
            return new BigNumber("42");
        }

        private void RecalculateStats()
        {

        }

        private BigNumber CalculateNexyUpgradeCoast()
        {
            return new BigNumber("42");
        }

        private BigNumber CalculateTotalDamage()
        {
            return new BigNumber("42");
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
    }
}
