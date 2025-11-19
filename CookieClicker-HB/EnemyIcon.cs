using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class EnemyIcon : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public EnemyIcon(string name, string path)
        {
            Name = name;
            ImagePath = path;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
