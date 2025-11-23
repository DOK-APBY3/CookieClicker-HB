using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CookieClicker_HB
{
    public class DamgeDealler : ColectableItem
    {
        

        private System.Windows.Point _position;
        protected System.Windows.Size _spriteSize;
        private double _llifeTime;
        protected Ellipse _sprite;

        public System.Windows.Point Position
        {
            get { return _position; }
            private set { _position = value; }
        }
        public System.Windows.Size SpriteSize
        {
            get { return _spriteSize; }
            private set { _spriteSize = value; }
        }
        public double LifeTime
        {
            get { return _llifeTime; }
            private set { _llifeTime = value; }
        }

        public Ellipse Sprite
        {
            get { return _sprite; }
            private set { _sprite = value; }
        }

        public DamgeDealler(System.Windows.Point position, double size, double lifeTime) : base(position, size, lifeTime)
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

        public bool isMouseOnObject(System.Windows.Point mousePointPos)
        {
            return false;
        }


        public Ellipse GetSprite()
        {
            return _sprite;
        }

        public bool onClick(Player player, System.Windows.Point mousePointPos)
        {
            return false;
        }
    }
}
