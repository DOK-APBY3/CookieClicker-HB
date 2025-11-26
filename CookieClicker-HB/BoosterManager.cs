using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public static class BoosterManager
    {

        private static bool _bossSpawnerActiveated = false;
        private static double _bossSpawnerTimeLeft;
        private static bool _clickSpeederActiveated = false;
        private static double _clickSpeederTimeLeft;
        private static double _clickSpeederDevider = 1;
        private static bool _damageBoosterActiveated = false;
        private static double _damageBoosterTimeLeft;
        private static double _damageMultiplyer = 1;
        private static bool _damageDeallerActive = false;
        private static bool _lifeTimeIncreeserActiveated = false;
        private static double _lifeTimeIncreeserTimeLeft;
        private static double _lifeTimeMultiplyer = 1;
        private static bool _spawnRateIncreeserActiveated = false;
        private static double _spawnRateIncreeserTimeLeft;
        private static double _spawnRateDevider = 1;

        public static bool BossSpawnerActivated
        {
            get { return _bossSpawnerActiveated; }
            set { _bossSpawnerActiveated = value;
                if (value) BossSpawnerTimeLeft = 30; }
        }
        public static double BossSpawnerTimeLeft
        {
            get { return _bossSpawnerTimeLeft; }
            private set { _bossSpawnerTimeLeft = value; }
        }


        public static bool ClickSpeederActiveated
        {
            get { return _clickSpeederActiveated; }
            set { _clickSpeederActiveated = value;
                if (value) ClickSpeederTimeLeft = 15; ClickSpeederDevider = 0.5;
            }
        }
        public static double ClickSpeederTimeLeft
        {
            get { return _clickSpeederTimeLeft; }
            private set { _clickSpeederTimeLeft = value; }
        }
        public static double ClickSpeederDevider
        {
            get { return _clickSpeederDevider; }
            private set { _clickSpeederDevider = value; }
        }


        public static bool DamadeBoosterActiveated
        {
            get { return _damageBoosterActiveated; }
            set { _damageBoosterActiveated = value;
                if (value) DamadeBoosterTimeLeft = 10; DamageMultiplyer = 2;
            }
        }
        public static double DamadeBoosterTimeLeft
        {
            get { return _damageBoosterTimeLeft; }
            private set { _damageBoosterTimeLeft = value; }
        }
        public static double DamageMultiplyer
        {
            get { return _damageMultiplyer; }
            private set { _damageMultiplyer = value; }
        }


        public static bool IsDamageIncreesed
        {
            get {
                if (_damageDeallerActive) { IsDamageIncreesed = false; return true; }
                return false;
            }
            set { _damageDeallerActive = value; }
        }


        public static bool LifeTimeIncreeserActiveated
        {
            get { return _lifeTimeIncreeserActiveated; }
            set { _lifeTimeIncreeserActiveated = value;
                if (value) LifeTimeIncreeserTimeLeft = 20; lifeTimeMultiplyer = 1.5;
            }
        }
        public static double LifeTimeIncreeserTimeLeft
        {
            get { return _lifeTimeIncreeserTimeLeft; }
            private set { _lifeTimeIncreeserTimeLeft = value; }
        }
        public static double lifeTimeMultiplyer
        {
            get { return _lifeTimeMultiplyer; }
            private set { _lifeTimeMultiplyer = value; }
        }


        public static bool SpawnRateIncreeserActiveated
        {
            get { return _spawnRateIncreeserActiveated; }
            set { _spawnRateIncreeserActiveated = value;
                if (value) SpawnRateIncreeserTimeLeft = 10; SpawnRateDevider = 0.75;
            }
        }
        public static double SpawnRateIncreeserTimeLeft
        {
            get { return _spawnRateIncreeserTimeLeft; }
            private set { _spawnRateIncreeserTimeLeft = value; }
        }
        public static double SpawnRateDevider
        {
            get { return _spawnRateDevider; }
            private set { _spawnRateDevider = value; }
        }


        public static void Update(double delta)
        {
            if (BossSpawnerActivated)
            {
                BossSpawnerTimeLeft -= delta;
                if (BossSpawnerTimeLeft < 0)
                {
                    BossSpawnerActivated = false;
                    BossSpawnerTimeLeft = 30;
                }
            }
            if (ClickSpeederActiveated)
            {
                ClickSpeederTimeLeft -= delta;
                if (ClickSpeederTimeLeft < 0)
                {
                    ClickSpeederActiveated = false;
                    ClickSpeederTimeLeft = 15;
                }
            }
            if (DamadeBoosterActiveated)
            {
                DamadeBoosterTimeLeft -= delta;
                if (DamadeBoosterTimeLeft < 0)
                {
                    DamadeBoosterActiveated = false;
                    DamadeBoosterTimeLeft = 10;
                }
            }
            if (LifeTimeIncreeserActiveated)
            {
                LifeTimeIncreeserTimeLeft -= delta;
                if (LifeTimeIncreeserTimeLeft < 0)
                {
                    LifeTimeIncreeserActiveated = false;
                    LifeTimeIncreeserTimeLeft =20;
                }
            }
            if (_spawnRateIncreeserActiveated)
            {
                SpawnRateIncreeserTimeLeft -= delta;
                if (SpawnRateIncreeserTimeLeft < 0)
                {
                    _spawnRateIncreeserActiveated = false;
                    SpawnRateIncreeserTimeLeft = 10;
                }
            }
        }

    }
}
