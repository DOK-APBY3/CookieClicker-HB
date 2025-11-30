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
    public class ClickSpeeder : ColectableItem
    {
        

        private System.Windows.Point _position;
        protected System.Windows.Size _spriteSize;
        private double _llifeTime;
        protected Ellipse _sprite;

        

        public ClickSpeeder(System.Windows.Point position, double size, double lifeTime) : base(position, size, lifeTime)
        {
            Position = position;
            SpriteSize = new System.Windows.Size(size, size);
            LifeTime = lifeTime;

            Sprite = new Ellipse();

            Sprite.Fill = Brushes.AliceBlue;
            Sprite.StrokeThickness = 2;
            Sprite.Stroke = Brushes.Black;

            Sprite.HorizontalAlignment = HorizontalAlignment.Center;
            Sprite.VerticalAlignment = VerticalAlignment.Center;
            Sprite.Width = SpriteSize.Width;
            Sprite.Height = SpriteSize.Height;
            Sprite.RenderTransform = new TranslateTransform(position.X, position.Y);
        }

        public override bool isMouseOnObject(System.Windows.Point mousePointPos)
        {
            return false;
        }


        public override Ellipse GetSprite()
        {
            return _sprite;
        }

        public override bool onClick(Player player, System.Windows.Point mousePointPos)
        {
            if (((mousePointPos.X > Position.X - SpriteSize.Width) && (mousePointPos.X < Position.X + SpriteSize.Width)) &&
                ((mousePointPos.Y > Position.Y - SpriteSize.Height) && (mousePointPos.Y < Position.Y + SpriteSize.Height)))
            {
                BoosterManager.ClickSpeederActiveated = true;
                return true;
            }
            else return false;

        }

        public override bool updateLifetime(double delta)
        {
            LifeTime -= delta;

            if (LifeTime > 0) return true;
            else return false;
        }
    }
}
