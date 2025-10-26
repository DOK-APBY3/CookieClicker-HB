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

namespace CookieClicker_HB;

public partial class MainWindow : Window
{
    List<EnemyIcon> listOfEnemyIcons = new List<EnemyIcon>();

    public MainWindow()
    {
        InitializeComponent();
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