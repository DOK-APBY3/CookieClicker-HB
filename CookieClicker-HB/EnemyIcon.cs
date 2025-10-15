using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class EnemyIcon
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public EnemyIcon(string name, string path)
        {
            Name = name;
            ImagePath = path;
        }

    }
}
