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

            BigNumber n1 = new BigNumber("24876512");
            BigNumber n2 = new BigNumber("1089478264");
            

            MessageBox.Show($"{n1 + n2}\n1114354776");
            //MessageBox.Show($"{n2 - n1}\n1064601752");
            MessageBox.Show($"{n1 - n2}\n-1064601752");
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
