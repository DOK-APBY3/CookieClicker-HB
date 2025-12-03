using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{

    public interface ISaveList<T>
    {
        //Сигнатура загрузки
        T Load(string path);
        //Сигнатура сохранения
        void Save(T data, string path);
    }

    public interface IEnemy
    {
        string Name { get; }
        BigNumber Max_hit_points { get; }
        BigNumber Gold_reward { get; }
        bool TakeDamage(BigNumber damage, out BigNumber reward);
    }

}
