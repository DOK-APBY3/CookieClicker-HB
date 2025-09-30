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

    FileManager saveLoader = new FileManager();

    public MainWindow()
    {
        InitializeComponent();

        ListOfEnemyTemplate listOfEnemys = new ListOfEnemyTemplate();
        ListsManager.addToGL("listOfEnemys", listOfEnemys);

        listOfEnemys.addEnemy("valik", "KUZN", 3, 3, 3.4, 5.7, 0.66);
        listOfEnemys.addEnemy("zlata", "KNYAZZ", 3, 3, 3.4, 5.7, 0.66);


        ListOfEnemyTemplate listOfEnemys2 = new ListOfEnemyTemplate();
        ListsManager.addToGL("listOfEnemys2", listOfEnemys2);

        listOfEnemys2.addEnemy("valik", "KUZN", 3, 3, 3.4, 5.7, 0.66);
        listOfEnemys2.addEnemy("zlata", "KNYAZZ", 3, 3, 3.4, 5.7, 0.66);


        saveLoader.SaveToSelectedFile();


        listOfEnemys.deleteEnemyByIndex(42);
    }
}