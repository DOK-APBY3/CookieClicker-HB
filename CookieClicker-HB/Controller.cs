using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;
using static System.Formats.Asn1.AsnWriter;

namespace CookieClicker_HB
{

    public class ControllerEventArgs : EventArgs
    {
        //ссылка на визуальное представление собираемого объекта
        public Ellipse sprite;
        public ControllerEventArgs(Ellipse sprite)
        {
            this.sprite = sprite;
        }
    }

    public delegate void SphereEvent(object sender, ControllerEventArgs e);


    public class Controller
    {
        private List<ColectableItem> objects = new List<ColectableItem>();
        private List<ColectableItem> objectsToDelete = new List<ColectableItem>();
        private double _spawnRate;
        private double _time;
        Random rnd = new Random();
        private double _maxLifeTime;
        private double _minLifeTime;
        private double _maxSpriteSize;
        private double _minSpriteSize;
        private Size _sceneSize;
        private double _points;
        private Player _player;


        public List<ColectableItem> Objects
        {
            get { return objects; }
            private set { objects = value; }
        }
        
        public double SpawnRate
        {
            get { return _spawnRate; }
            set { _spawnRate = value; }
        }

        public double Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public double MaxLifeTime
        {
            get { return _maxLifeTime; }
            set { _maxLifeTime = value; }
        }

        public double MinLifeTime
        {
            get { return _minLifeTime; }
            set { _minLifeTime = value; }
        }

        public double MaxSpriteSize
        {
            get { return _maxSpriteSize; }
            set { _maxSpriteSize = value; }
        }

        public double MinSpriteSize
        {
            get { return _minSpriteSize; }
            set { _minSpriteSize = value; }
        }

        public Size SceneSize
        {
            get { return _sceneSize; }
            set { _sceneSize = value; }
        }

        public double Points
        {
            get { return _points; }
            set { _points = value; }
        }



        //ссылка на обработчик события добавления объекта в сцену
        public event SphereEvent addObject;

        //ссылка на обработчики событий удаления объекта из сцены
        public event SphereEvent removeObject;

        public Controller(double spawnRate, int startTime, Size sceneSize, Player player)
        {
            rnd = new Random();
            objects = new List<ColectableItem>();
            SpawnRate = spawnRate;
            Time = startTime;
            SceneSize = sceneSize;
            Points = 0;
            MinLifeTime = 2;
            MaxLifeTime = 10;
            MinSpriteSize = 20;
            MaxSpriteSize = 40;

            _player = player;
        }

        public void spawnObject()
        {
            ColectableItem newItem = null;
            int nextType = rnd.Next(1, 49);
            double newSize = (rnd.NextDouble() *(MaxSpriteSize - MinSpriteSize)) + MinSpriteSize;
            double newLifeTime = ((rnd.NextDouble() * (MaxLifeTime - MinLifeTime)) + MinLifeTime) * BoosterManager.lifeTimeMultiplyer;
            Point newPos = new Point();
            newPos.X = rnd.Next(Convert.ToInt32(newSize), Convert.ToInt32(SceneSize.Width - newSize));
            newPos.Y = rnd.Next(Convert.ToInt32(newSize), Convert.ToInt32(SceneSize.Height - newSize));

            if (nextType <= 8) newItem = new ClickSpeeder(newPos, newSize, newLifeTime);
            else if (nextType <= 16) newItem = new DamageBooster(newPos, newSize, newLifeTime);
            else if (nextType <= 24) newItem = new DamgeDealler(newPos, newSize, newLifeTime);
            else if (nextType <= 32) newItem = new GoldGiver(newPos, newSize, newLifeTime);
            else if (nextType <= 40) newItem = new LifeTimeIncreeser(newPos, newSize, newLifeTime);
            else if (nextType <= 48) newItem = new SpawnRateIncreeser(newPos, newSize, newLifeTime);
            else newItem = new BossSpawner(newPos, newSize, newLifeTime);

            Objects.Add(newItem);

            addObject?.Invoke(this, new ControllerEventArgs(newItem.GetSprite()));


        }

        

        public void Update(double delta)
        {

            if (Time >0)
            {
                Time -= delta;
            }
            else
            {
                Time = SpawnRate * BoosterManager.SpawnRateDevider;
                spawnObject();
            }

            foreach (ColectableItem item in Objects)
            {
                if (! item.updateLifetime(delta))
                {
                    objectsToDelete.Add(item);
                }
            }

            

        }

        public void DeleteAll()
        {
            foreach (ColectableItem item in objectsToDelete)
            {
                deleteObject(item);
            }
            objectsToDelete.Clear();
        }


        public bool mouseClick(System.Windows.Point mousePos)
        {
            ColectableItem DeletengObj = null;

            bool isClick = false;
             foreach (ColectableItem obj in objects)
             {
                if (obj.onClick(_player, mousePos))
                {
                    
                    isClick = true;

                    DeletengObj = obj;
                    break;
                }
             }
            if (DeletengObj != null)
            {
                deleteObject(DeletengObj);
            }

            return isClick;
        }

        
        private void deleteObject(ColectableItem obj)
        {

            removeObject?.Invoke(this, new ControllerEventArgs(obj.GetSprite()));
            Objects.Remove(obj);
            
        }

        public void clear()
        {
            foreach (ColectableItem item in objects)
            {
                objectsToDelete.Add(item);
            }
            
            DeleteAll();
        }
    }
}
