using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Threading;

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

        private Controller controller;
        private DispatcherTimer timer;


        


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


            Gamer = new Player(0.5);
            SimpleStatsPanel.DataContext = Gamer;
            GlobalStatPanel.DataContext = Gamer;
            PlayerUpgrasePanel.DataContext = Gamer;
            PlayerClickUpgrasePanel.DataContext = Gamer;
            EnemyZavod.AddPlayer(Gamer);

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += Timer_Tick;
            
            Size sceneSize = new Size(SphereContainer.Width, SphereContainer.Height);
            controller = new Controller(2, 2, sceneSize, Gamer);

            
            enemyList.loadFromJson(@"C:\Users\arbuz\source\repos\DOK-APBY3\CookieClicker-HB\CookieClicker-HB\icons\Monsters\RUMagicalEnemiesStack.json");


            EnemyTemplate tCE = enemyList.ReturnRandomEnemy();

            Current_Enemy = EnemyZavod.CreateEnemyFromTemplate(tCE);
            UpgateHP();

            EnemyPanel.DataContext = Current_Enemy; 

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            controller.Update(0.1);
            Gamer.update(0.1);
            Update(0.1);
        }

        private void Update(double delta)
        {
            if (controller.IsChange) // отрисовка новых точек если что-то поменялось
            {
                if (controller.NewObjects.Count > 0)
                {
                    foreach (ColectableItem obj in controller.NewObjects)
                    {
                        SphereContainer.Children.Add(obj.Sprite);
                    }
                }
                if (controller.DeletedObjects.Count > 0)
                {
                    foreach (ColectableItem obj in controller.DeletedObjects)
                    {
                        SphereContainer.Children.Remove(obj.Sprite);
                    }
                }

                controller.ChangesDone();
            }
        }


        private void SphereContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Gamer.CanClick)
            {
                
                Point mousePos = e.GetPosition(SphereContainer);
                if (controller.mouseClick(mousePos))
                {
                    e.Handled = true;
                    Gamer.mouseCkick();
                }
            }
        }



        private void EnemyWasClicked(object sender, RoutedEventArgs e)
        {
            if (Gamer.CanClick)
            {
                BigNumber reward;
                bool isKilled = Current_Enemy.TakeDamage(Gamer.DealDamage(), out reward);

                Gamer.mouseCkick();

                if (isKilled)
                {
                    Gamer.AddGold(reward);
                    Gamer.EnemyKilled();
                    CreateNewEnemy();
                }
                else UpgateHP();
            }
        }

        private void CreateNewEnemy()
        {

            
            EnemyTemplate tCE;

            if (BoosterManager.BossSpawnerActivated) tCE = enemyList.getEnemyByIndex(5);
            else tCE = enemyList.ReturnRandomEnemy();

            

            Current_Enemy = EnemyZavod.CreateEnemyFromTemplate(tCE);
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
                
            }
            else
            {
                MessageBox.Show("А! А! А! Денег не ма!");
            }
        }
        private void ClickUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if (Gamer.TryUpgradeClick())
            {

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
