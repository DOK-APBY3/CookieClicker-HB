using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookieClicker_HB;

public partial class MainWindow : Window
{
    List<EnemyIcon> listOfEnemyIcons = new List<EnemyIcon>();

    public MainWindow()
    {
        InitializeComponent();
    }

    public void LoadAllIconsFromFolder(string path)
    {
        string fileType = "*.png";

        string[] paths = Directory.GetFiles(path, fileType);

        foreach (string iconPath in paths)
        {
            string[] m = iconPath.Split(new char[] { '\\' });

            listOfEnemyIcons.Add(new EnemyIcon(m.Last(), iconPath));

        }
    }
}