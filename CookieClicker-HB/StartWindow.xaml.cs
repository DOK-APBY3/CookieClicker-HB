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
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditorButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newMainWindow = new MainWindow();
            Application.Current.MainWindow = newMainWindow;
            newMainWindow.Show();
            this.Close();
        }

        private void GamingButton_Click(object sender, RoutedEventArgs e)
        {

            ClickerWindow newMainWindow = new ClickerWindow();
            Application.Current.MainWindow = newMainWindow;
            newMainWindow.Show();
            this.Close();
        }
    }
}
