
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
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

    EnemyTemplate currentEnemy;

    bool loadingFlag = true;

    string currentTypeName = "CasualEnemeTemplate";


    public MainWindow()
    {
        InitializeComponent();

        testing();

        DataContext = enemyList;
        EnemyListBox.ItemsSource = enemyList.enemies;
    }

    private void testing()
    {
        LoadIcons();
        
    }

    public void deleteEnemyWithThisName(string name)
    {
        enemyList.deleteEnemyByName(name);
    }


    public void takeEnemyWithThisName(string name)
    {
        enemyList.getEnemyByName(name);
    }

    
    public void enemy_AddRandomByName(string name)
    {
        int newIcon = rnd.Next(0, listOfEnemyIcons.Count);
        enemyList.addEnemy(currentTypeName , name, listOfEnemyIcons[newIcon].Name, listOfEnemyIcons[newIcon].ImagePath, "ganganstyle",
            rnd.Next(1, 10),
            rnd.Next(1, 10),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble() * 10, 2),
            Math.Round(rnd.NextDouble(), 2) , []) ;
    }

    private void IconLoadingButton_Click(object sender, RoutedEventArgs e)
    {
        LoadIcons();
    }
    
    private void LoadIcons()
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

        if (iconsOnScreen.SelectedItem != null && currentEnemy != null)
        {            currentEnemy!.IconName = (IconListBox.SelectedItem as EnemyIcon)!.Name;
            currentEnemy!.IconSourse = (IconListBox.SelectedItem as EnemyIcon)!.ImagePath;
            EnemyIconName.Text = (IconListBox.SelectedItem as EnemyIcon)!.Name;
            EnemyIcon.Source = new BitmapImage(new Uri((IconListBox.SelectedItem as EnemyIcon)!.ImagePath));

        }
    }


    private void EnemyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        ListBox enemyListBox = sender as ListBox;
        currentEnemy = enemyListBox.SelectedItem as EnemyTemplate;
        if (currentEnemy != null)
        {
            EnemyIconName.Text = currentEnemy!.IconName;
            EnemyIcon.Source = new BitmapImage(new Uri(currentEnemy!.IconSourse));
        }
        
    }



    private void AddingButton_Click(object sender, RoutedEventArgs e)
    {
        enemy_AddRandomByName("New enemy");
    }

    private void RemovingButton_Click(object sender, RoutedEventArgs e)
    {
        if (currentEnemy != null)
        {
            enemyList.deleteEnemyByName(currentEnemy.Name);
            if (enemyList.enemies.Count != 0)
            {
                currentEnemy = enemyList.enemies[0];
            }
            else
            {
                currentEnemy = null;
            }
            EnemyListBox.SelectedItem = currentEnemy;

            EnemyListBox.ItemsSource = enemyList.enemies;
        }
        
        
    }

    private void NormalaiseSR_Click(object sender, RoutedEventArgs e)
    {
        enemyList.normalizeChances();
    }
    private void SavingButton_Click(object sender, RoutedEventArgs e)
    {
        FileManager.SaveToSelectedFile(enemyList);
    }

    private void LoadingButton_Click(object sender, RoutedEventArgs e)
    {
        

        if (loadingFlag)
        {
            MessageBox.Show("ВНИМАНИЕ!!! При загрзке все несохранённые данные будут утеряны! Если вы готовы загрузить список нажмите на кнопку загрузки ещё раз");
            loadingFlag = false;
        }
        else
        {
            FileManager.LoadFromSelectedFile(enemyList);
            DataContext = enemyList;
            EnemyListBox.ItemsSource = enemyList.enemies;
            loadingFlag = true;
        }

        
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        StartWindow newMainWindow = new StartWindow();
        Application.Current.MainWindow = newMainWindow;
        newMainWindow.Show();
        this.Close();
    }

    private void EscapeButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void EnemyTypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox TypeCB = sender as ComboBox;

        ComboBoxItem currentType = TypeCB.SelectedItem as ComboBoxItem;

        currentTypeName = currentType.Name;
    }
}