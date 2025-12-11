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
    public class BossSpawner : ColectableItem
    {
        
        private double _workingTime;
        private System.Windows.Point _position;
        protected System.Windows.Size _spriteSize;
        private double _llifeTime;
        protected Ellipse _sprite;

        

        public BossSpawner(System.Windows.Point position, double size, double lifeTime) : base(position, size, lifeTime)
        {
            Position = position;
            SpriteSize = new System.Windows.Size(size*2, size*2);
            LifeTime = lifeTime;

            Sprite = new Ellipse();

            Sprite.Fill = Brushes.DarkGreen;
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



        public override bool onClick(Player player, System.Windows.Point mousePointPos)
        {
            if (((mousePointPos.X > Position.X - SpriteSize.Width) && (mousePointPos.X < Position.X + SpriteSize.Width)) &&
                ((mousePointPos.Y > Position.Y - SpriteSize.Height) && (mousePointPos.Y < Position.Y + SpriteSize.Height)))
            {
                BoosterManager.BossSpawnerActivated = true;
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
