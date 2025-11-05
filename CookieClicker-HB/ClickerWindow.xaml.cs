using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class ClickerWindow : Window
    {
        public ClickerWindow()
        {
            InitializeComponent();
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

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
