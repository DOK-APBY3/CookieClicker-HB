using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CookieClicker_HB
{
    public abstract class ColectableItem
    {
        private System.Windows.Point _position;
        protected System.Windows.Size _spriteSize;
        private double _llifeTime;
        protected Ellipse _sprite;

        public abstract System.Windows.Point Position
        {
            get;
            set;
        }
        public abstract System.Windows.Size SpriteSize
        {
            get;
            set;
        }
        public abstract double LifeTime
        {
            get;
            set;
        }
        
        public abstract Ellipse Sprite
        {
            get;
            set;
        }

        public ColectableItem(System.Windows.Point position, double size, double lifeTime)
        {
            Position = position;
            SpriteSize = new System.Windows.Size(size, size);
            LifeTime = lifeTime;

            Sprite = new Ellipse();

            Sprite.Fill = Brushes.Aquamarine;
            Sprite.StrokeThickness = 2;
            Sprite.Stroke = Brushes.Black;

            Sprite.HorizontalAlignment = HorizontalAlignment.Center;
            Sprite.VerticalAlignment = VerticalAlignment.Center;
            Sprite.Width = SpriteSize.Width;
            Sprite.Height = SpriteSize.Height;
            Sprite.RenderTransform = new TranslateTransform(position.X, position.Y);
        }

        public abstract bool isMouseOnObject(System.Windows.Point mousePointPos); // а зачем??


        public abstract Ellipse GetSprite();

        public abstract bool onClick(Player player, System.Windows.Point mousePointPos);

        public abstract bool updateLifetime(double delta);
    }
}
