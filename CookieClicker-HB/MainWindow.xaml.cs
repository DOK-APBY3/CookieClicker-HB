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

        

        //ListsManager.SaveToJson();

        //listOfEnemys.deleteEnemyByIndex(42);


        ListsManager.LoadingEvent += takeListsFromFileManager;

        FileManager.LoadFromSelectedFile();
    }

    public void enemy_AddRandomByNameToList(string name, string iconName, ListOfEnemyTemplate neededList)
    {
        neededList.addEnemy(name, iconName,
            rnd.Next(1, 10),
            rnd.Next(1, 10),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble(), 2));
    }

     

    public void takeListsFromFileManager(Dictionary<string, UniversalListTemplate> allLists)
    {
        ListOfEnemyTemplate LET1st = allLists["LET|1st"] as ListOfEnemyTemplate;
        ListOfEnemyTemplate LET2st = allLists["LET|2st"] as ListOfEnemyTemplate;
    }

}