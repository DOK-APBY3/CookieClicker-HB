
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;
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
using System.Xml.Linq;

namespace CookieClicker_HB;

public partial class MainWindow : Window
{

    Random rnd = new Random();

    ListOfEnemyTemplate enemyList = new ListOfEnemyTemplate();

    List<EnemyIcon> listOfEnemyIcons = new List<EnemyIcon>();


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

    private void IconLoadingButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFolderDialog dlg = new OpenFolderDialog();
        dlg.ShowDialog();
        LoadAllIconsFromFolder(dlg.FolderName);
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

        IconListBox.ItemsSource = listOfEnemyIcons;
        //IconListBox.DataContext = listOfEnemyIcons;
    }


    private void IconListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox iconsOnScreen = sender as ListBox;

        if (iconsOnScreen.SelectedItem is Image selectedImage && iconsOnScreen.SelectedItem != null)
        {
            string iconName = System.IO.Path.GetFileName(selectedImage.Source.ToString());
            // CurrentEnemy.IconName = iconName; будет когда объеденим
        }
    }


    private void EnemyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }



    private void AddingButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void RemovingButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void SavingButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void LoadingButton_Click(object sender, RoutedEventArgs e)
    {

    }




    private void EscapeButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    
}