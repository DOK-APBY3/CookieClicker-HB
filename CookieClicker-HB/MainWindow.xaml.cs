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
using System.Xml.Linq;

namespace CookieClicker_HB;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Random rnd = new Random();

    public MainWindow()
    {
        InitializeComponent();

        ListOfEnemyTemplate enemyList1 = new ListOfEnemyTemplate();

        enemy_AddRandomByNameToList("labubsli", "stalnoy zad", "bosses", enemyList1);

        FileManager.SaveToSelectedFile(enemyList1);

        //listOfEnemys.deleteEnemyByIndex(42);


        

        FileManager.LoadFromSelectedFile(enemyList1);
    }

    public void enemy_AddRandomByNameToList(string name, string iconName, string groupe, ListOfEnemyTemplate neededList)
    {
        neededList.addEnemy(name, iconName, groupe,
            rnd.Next(1, 10),
            rnd.Next(1, 10),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble(), 2));
    }
}