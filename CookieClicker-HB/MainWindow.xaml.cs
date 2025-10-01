using System.Text;
using System.Text.RegularExpressions;
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

    ListOfEnemyTemplate enemyList = new ListOfEnemyTemplate();

    public MainWindow()
    {
        InitializeComponent();

        testing();
    }

    private void testing()
    {
        enemy_AddRandomByNameToList("labubsli", "stalnoy zad", "bosses", enemyList);
        //listOfEnemys.deleteEnemyByIndex(42);
    }

    public void deleteEnemyWithThisName(string name)
    {
        enemyList.deleteEnemyByName(name);
    }

    public void deleteEnemyWithThisIndex(int index)
    {
        enemyList.deleteEnemyByIndex(index);
    }

    public void takeEnemyWithThisName(string name)
    {
        enemyList.getEnemyByName(name);
    }

    public void takeEnemyWithThisIndex(int index)
    {
        enemyList.getEnemyByIndex(index);
    }

    //public void AddCurrentEnemy()  будет работать когда будеи интерфейс
    //{
    //    enemyList.addEnemy(name, iconName, groupe,
    //        rnd.Next(1, 10),
    //        rnd.Next(1, 10),
    //        Math.Round(rnd.NextDouble() * 10, 2),
    //        Math.Round(rnd.NextDouble() * 10, 2),
    //        Math.Round(rnd.NextDouble(), 2));
    //}

    public void saveListOfEnemies()
    {
        FileManager.SaveToSelectedFile(enemyList);
    }

    public void loadListOfEnemies()
    {
        FileManager.LoadFromSelectedFile(enemyList);
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