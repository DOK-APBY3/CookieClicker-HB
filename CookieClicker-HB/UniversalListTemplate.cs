using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public abstract class UniversalListTemplate
    {

        public abstract void saveToJson(string path);

        public abstract List<EnemyTemplate> GetCurrentList();
    }
}
