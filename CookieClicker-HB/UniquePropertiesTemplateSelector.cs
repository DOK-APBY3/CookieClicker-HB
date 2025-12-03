using CookieClicker_HB.EnemyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CookieClicker_HB
{

    public class UniquePropertiesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ArmoredTemplate { get; set; }
        public DataTemplate HealingTemplate { get; set; }
        public DataTemplate NinjaTemplate { get; set; }
        public DataTemplate EmptyTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                // Замените на реальные имена классов
                if (item.GetType() == typeof(ArmoredEnemyTemplaye))
                {
                    return ArmoredTemplate;
                }
                else if (item.GetType() == typeof(HealingEnemyTemplate))
                {
                    return HealingTemplate;
                }
                else if (item.GetType() == typeof(NinjaEnemyTemplate))
                {
                    return NinjaTemplate;
                }
            }
            // Возвращаем пустой шаблон для врагов без уникальных свойств
            return EmptyTemplate;
        }
    }

}
