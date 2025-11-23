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

        private int _lvl;// уровень пока хз чего   -    теперь это отвечает за базу по ур сложности         1
        private int _swordLvl; // lvl mеcha                                                                 1
        private BigNumber _gold;// колво золота                                                             1
        private BigNumber _GoldRaised;//заработано золота (для статистики) (возможно в перспективе          1
        private BigNumber _damage;//урон                                     сделать статистику             1
        private double _damageMod;//модификатор для прокачки урона            в отделььной вкладке)         1
        private BigNumber _damageDealed;//количество нанесённого урона                                      1
        private BigNumber _swordupgradeCost;// стоймость прокачки меча                                      1
        private double _upgradeMod;//модификатор стоймости                                                  1
        private int _killedEnemy;//убитые враги


        private bool _canClick = true;
        private double _timeBeforeClick;
        private CountDownTimer _countdownTimer = new CountDownTimer();

        private bool _bossSpawnerActiveated;
        private double _bossSpawnerTimeLeft;
        private bool _clickSpeederActiveated;
        private double _clickSpeederTimeLeft;
        private bool _damadeBoosterActiveated;
        private double _damadeBoosterTimeLeft;

        private int _clickLvl;
        private BigNumber _clickupgradeCost;// стоймость прокачки click  

        public int ClickLvl
        { 
            get { return _clickLvl; }
            set { _clickLvl = value;
                OnPropertyChanged("ClickLvl");
            }
        }
        public BigNumber ClickupgradeCost
        {
            get { return _clickupgradeCost; }
            set { _clickupgradeCost = value;
                OnPropertyChanged("ClickupgradeCost");
            }
        }

        public bool BossSpawnerActivated
        {
            get { return _bossSpawnerActiveated; }
            set { _bossSpawnerActiveated = value; }
        }
        public double BossSpawnerTimeLeft
        {
            get { return _bossSpawnerTimeLeft; }
            set { _bossSpawnerTimeLeft = value; }
        }
        public bool ClickSpeederActiveated
        {
            get { return _clickSpeederActiveated; }
            set { _clickSpeederActiveated = value; }
        }
        public double ClickSpeederTimeLeft
        {
            get { return _clickSpeederTimeLeft; }
            set { _clickSpeederTimeLeft = value; }
        }
        public bool DamadeBoosterActiveated
        {
            get { return _damadeBoosterActiveated; }
            set { _damadeBoosterActiveated = value; }
        }
        public double DamadeBoosterTimeLeft
        {
            get { return _damadeBoosterTimeLeft; }
            set { _damadeBoosterTimeLeft = value; }
        }


        public bool CanClick
        { 
            get { return _canClick; } 
            private set { 
                if (!value)
                {
                    _countdownTimer.TargetTime = TimeBeforeClick;
                }
                _canClick = value; }
        }
        public double TimeBeforeClick
        {
            get { return _timeBeforeClick * BoosterManager.ClickSpeederDevider; }
            private set { _timeBeforeClick = value; }
        }

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

        public Player(double timeBeforeClick)
        {
            Lvl = 1;
            SwordLvl = 1;
            ClickLvl = 1;
            Gold = new BigNumber("10");
            GoldRaised = new BigNumber("0");
            Damage = new BigNumber("2");
            DamageMod = 1.25;
            DamageDealed = new BigNumber("0");
            SwordUpgradeCost = new BigNumber("15");
            ClickupgradeCost = new BigNumber("15");
            UpgradeMod = 1.35;
            KilledEnemy = 0;
            TimeBeforeClick = timeBeforeClick;

        }

        public void mouseCkick()
        {
            CanClick = false;
        }
        public void countdownEnded()
        {
            CanClick = true;
        }
        public void update(double delta)
        {
            if (_countdownTimer.TargetTime <= 0)
            {
                countdownEnded();
            }
            _countdownTimer.update(delta);
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

        public bool TryUpgradeClick()
        {
            if (TrySpendGold(ClickupgradeCost))
            { UpgradeClick(); return true; }
            else return false;
        }

        public void UpgradeClick()
        {
            removeGold(ClickupgradeCost);
            ClickLvl += 1;
            _timeBeforeClick = _timeBeforeClick * 0.8;

            ClickupgradeCost = CalculateNextClickUpgradeCoast();
        }

        private BigNumber CalculateNextClickUpgradeCoast()
        {
            BigNumber newClickUpgradeCost;


            if (ClickLvl > 5)
            {

                double coastRandomComponent = (rnd.NextDouble() * (2 * UpgradeMod * (ClickLvl - 4))) - UpgradeMod * (ClickLvl - 4);

                newClickUpgradeCost = (ClickupgradeCost * (UpgradeMod * (ClickLvl - 3) + coastRandomComponent)) / (ClickLvl / 2.8);

            }
            else
            {
                int tmpClickLvl = ClickLvl;
                ClickLvl = 5;

                double coastRandomComponent = (rnd.NextDouble() * (2 * UpgradeMod * (ClickLvl - 4))) - UpgradeMod * (ClickLvl - 4);

                newClickUpgradeCost = ClickupgradeCost * (UpgradeMod * (ClickLvl - 3) + coastRandomComponent);

                ClickLvl = tmpClickLvl;
            }

            return newClickUpgradeCost;
        }

        public BigNumber DealDamage()
        {
            BigNumber boostedDamage;

            if (BoosterManager.IsDamageIncreesed)
            {
                boostedDamage = Damage * 10;
                DamageDealed += boostedDamage;
                return boostedDamage;
            }
            if (BoosterManager.DamadeBoosterActiveated)
            {
                boostedDamage = Damage * BoosterManager.DamageMultiplyer;
                DamageDealed += boostedDamage;
                return boostedDamage;
            }
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
            BigNumber newSwordUpgradeCost;


            if ( SwordLvl > 5)
            {

                double coastRandomComponent = (rnd.NextDouble() * (2 * UpgradeMod * (SwordLvl - 4))) - UpgradeMod * (SwordLvl - 4);

                newSwordUpgradeCost = (SwordUpgradeCost * (UpgradeMod * (SwordLvl - 3) + coastRandomComponent))/(SwordLvl/2.65);

            }
            else
            {
                int tmpSwordLvl = SwordLvl;
                SwordLvl = 5;

                double coastRandomComponent = (rnd.NextDouble() * (2 * UpgradeMod * (SwordLvl - 4))) - UpgradeMod * (SwordLvl - 4);

                newSwordUpgradeCost = SwordUpgradeCost * (UpgradeMod * (SwordLvl - 3) + coastRandomComponent);

                SwordLvl = tmpSwordLvl;
            }

            return newSwordUpgradeCost;
        }
        private BigNumber CalculateTotalDamage()
        {
            double damageRandomComponent = (rnd.NextDouble() * (2 * DamageMod * (SwordLvl - 1))) - DamageMod * (SwordLvl - 1);

            BigNumber newDamage = Damage * DamageMod + new BigNumber(Convert.ToString(Convert.ToInt32(DamageMod * SwordLvl + damageRandomComponent)));
            //BigNumber newDamage = Damage * (DamageMod * SwordLvl + damageRandomComponent);

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
