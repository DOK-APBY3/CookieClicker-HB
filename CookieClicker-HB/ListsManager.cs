using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;


namespace CookieClicker_HB
{
    static class ListsManager
    {
        // Храним сразу сериализуемые данные
        private static Dictionary<string, UniversalListTemplate> allLists = new Dictionary<string, UniversalListTemplate>();

        public static void addToGL(string listName, UniversalListTemplate data)//добавление нового списка в словарь
        {
            allLists[listName] = data;
        }

        public static void deleteFromGl(string listName)//удаление списка из словаря по ключу
        {
            allLists.Remove(listName);
        }

        public static Dictionary<string, UniversalListTemplate> AllLists // публичный метод для доступа к alllists
        {
            get { return allLists; }
            set { MessageBox.Show("NO NO NO Mr.Fish! You cant edit GlobalList Like This "); }
        }


        public static void SaveToJson()// часть цила сохранения
        {
            Dictionary<string, List<EnemyTemplate>> dctWithAllLists = new Dictionary<string, List<EnemyTemplate>>();// создаём словарь со списками list<enemies> для упрощения сериализации

            foreach (var item in allLists)
            {
                dctWithAllLists[item.Key] = item.Value.GetCurrentList();// заполняем его
            }

            FileManager.SaveToSelectedFile(dctWithAllLists);// передаём словарь сохранятелю


        }

        public delegate void FileLoaded(Dictionary<string, UniversalListTemplate> value);
        public static event FileLoaded? LoadingEvent;

        public static void LoadFromJson(Dictionary<string, List<EnemyTemplate>> loadedData)// часть цикла загрузки
        {
            foreach (var item in loadedData)// перебираем загруженные элементы словаря для разбивки по listOff-ам пвзных классов
            {
                string key = item.Key;
                string[] nameOfflist = ((key).Split('|'));
                string typeOffList = nameOfflist[0];

                switch (typeOffList) // по префиксу названия определяем тип списка и создаём соотвествующиё объект в allLists для того чтобы не реализовывать вообще всё в UniversalListTemplate
                {
                    case "LET":

                        ListOfEnemyTemplate tmpEnemyList = new ListOfEnemyTemplate();
                        tmpEnemyList.addListOfEnemys(item.Value);
                        allLists[key] = tmpEnemyList;
                        break;
                    
                }

            }

            LoadingEvent?.Invoke(allLists);
        }

    }
}
