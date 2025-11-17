using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CookieClicker_HB
{
    /// <summary>
    /// Логика взаимодействия для ClickerWindow.xaml
    /// </summary>
    public partial class ClickerWindow : Window, INotifyPropertyChanged
    {
        Enemy Current_Enemy;

        ListOfEnemyTemplate enemyList = new ListOfEnemyTemplate();

        Random rnd = new Random();

        private Player _gamer;

        public Player Gamer
        {
            get => _gamer;
            set
            {
                _gamer = value;
                OnPropertyChanged("Gamer"); // Уведомляем, что свойство Gamer изменилось
            }
        }



        public ClickerWindow()
        {
            InitializeComponent();

            Gamer = new Player();
            SimpleStatsPanel.DataContext = Gamer;
            GlobalStatPanel.DataContext = Gamer;
            PlayerUpgrasePanel.DataContext = Gamer;


            string jsonString = File.ReadAllText(@"C:\Users\arbuz\source\repos\DOK-APBY3\CookieClicker-HB\CookieClicker-HB\icons\Monsters\RUCasualEnemiesStack.json");
            enemyList.loadFromJson(jsonString);

            EnemyTemplate tCE = enemyList.ReturnRandomEnemy();

            Current_Enemy = new Enemy(tCE.Name, new BigNumber(tCE.BaseLife.ToString()), new BigNumber(tCE.BaseGold.ToString()), new EnemyIcon(tCE.IconName, tCE.IconSourse));
            UpgateHP();

            EnemyPanel.DataContext = Current_Enemy; 
        }



        private void EnemyWasClicked(object sender, RoutedEventArgs e)
        {
            BigNumber reward;
            bool isKilled = Current_Enemy.TakeDamage(Gamer.DealDamage(), out reward);

            if (isKilled)
            {
                Gamer.AddGold(reward);
                Gamer.EnemyKilled();
                CreateNewEnemy();
            }
            else UpgateHP();

        }

        private void CreateNewEnemy()
        {
            int heroeLvl = Gamer.Lvl;
            EnemyTemplate tCE = enemyList.ReturnRandomEnemy();

            BigNumber new_HP = new BigNumber(tCE.BaseLife.ToString());
            double lifeMod = tCE.LifeModifier;
            double HPRandomComponent = (rnd.NextDouble() * (2 * lifeMod * (heroeLvl - 2))) - lifeMod * (heroeLvl - 2);
            new_HP = new_HP * (lifeMod * (heroeLvl - 1) * (heroeLvl - 1) + HPRandomComponent);

            BigNumber new_Gold = new BigNumber(tCE.BaseGold.ToString());
            double GoldMod = tCE.LifeModifier;
            double GoldRandomComponent = (rnd.NextDouble() * (2 * GoldMod * (heroeLvl - 2))) - GoldMod * (heroeLvl - 2);
            new_Gold = new_Gold * (GoldMod * (heroeLvl - 1) * (heroeLvl - 1) + GoldRandomComponent);

            Current_Enemy = new Enemy(tCE.Name, new_HP, new_Gold, new EnemyIcon(tCE.IconName, tCE.IconSourse));
            UpgateHP();
            EnemyPanel.DataContext = Current_Enemy;
        }


        private void UpgateHP()
        {
            BigInteger MaxHP = Current_Enemy.Max_hit_points.ToBigInteger();
            BigInteger CurHP = Current_Enemy.Current_hit_points.ToBigInteger();


            if (CurHP >= MaxHP)
            {
                enemy_Hp.Value = 100.0;
            }
            else if (CurHP.IsZero)
            {
                enemy_Hp.Value = 0.0;
            }
            else
            {

                // Умножаем CurrentHP на 100 (или на большее число для получения дробной части) -
                BigInteger numerator = CurHP * 100;

                // Выполняем целочисленное деление: (CurrentHP * 100) / MaxHP
                BigInteger percentageInteger = numerator / MaxHP;

                // Остаток от деления: (CurrentHP * 100) % MaxHP
                // BigInteger percentageRemainder = numerator % MaxHP;

                // Присваиваем целую часть процента ProgressBar'у
                // BigInteger можно безопасно привести к double, если он сам по себе не выходит за диапазон double
                // Для значений процента (до 100) это всегда в порядке.
                enemy_Hp.Value = (double)percentageInteger;
            }
        }


        private void SwordUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if (Gamer.TryUpgradeSword())
            {
                Gamer.UpgradeSword();
            }
            else
            {
                MessageBox.Show("А! А! А! Денег не ма!");
            }
        }

        private void SavingButton_Click(object sender, RoutedEventArgs e)
        {
            //FileManager.SaveToSelectedFile(enemyList);
        }

        private void LoadingButton_Click(object sender, RoutedEventArgs e)
        {


            //if (loadingFlag)
            //{
            //    MessageBox.Show("ВНИМАНИЕ!!! При загрзке все несохранённые данные будут утеряны! Если вы готовы загрузить список нажмите на кнопку загрузки ещё раз");
            //    loadingFlag = false;
            //}
            //else
            //{
            //    FileManager.LoadFromSelectedFile(enemyList);
            //    DataContext = enemyList;
            //    EnemyListBox.ItemsSource = enemyList.enemies;
            //    loadingFlag = true;
            //}


        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow newMainWindow = new StartWindow();
            Application.Current.MainWindow = newMainWindow;
            newMainWindow.Show();
            this.Close();
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
