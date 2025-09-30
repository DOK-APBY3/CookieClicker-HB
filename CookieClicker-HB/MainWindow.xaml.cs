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



        ListOfEnemyTemplate listOfEnemys = new ListOfEnemyTemplate();
        listOfEnemys.addEnemy("valik", "KUZN",
            rnd.Next(1, 10),
            rnd.Next(1, 10),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble(), 2));
        listOfEnemys.addEnemy("zlata", "KNYAZZ",
            rnd.Next(1, 10),
            rnd.Next(1, 10),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble(), 2));
        ListsManager.addToGL("1st", listOfEnemys);

        ListOfEnemyTemplate listOfEnemys2 = new ListOfEnemyTemplate();
        listOfEnemys2.addEnemy("valik", "KUZN", 
            rnd.Next(1, 10),
            rnd.Next(1, 10),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble(), 2));
        listOfEnemys2.addEnemy("zlata", "KNYAZZ",
            rnd.Next(1, 10),
            rnd.Next(1, 10),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble(), 2));
        ListsManager.addToGL("2st", listOfEnemys2);


        ListsManager.SaveToJson();

        //listOfEnemys.deleteEnemyByIndex(42);
    }
}