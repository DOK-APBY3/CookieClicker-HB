using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class Controller
    {
        private List<ColectableItem> objects = new List<ColectableItem>();
        private double _spawnRate;
        private double _time;
        Random rnd = new Random();
        private double _maxLifeTime;
        private double _minLifeTime;
        private double _maxSpriteSize;
        private double _minSpriteSize;
        private Size _sceneSize;
        private double _points;


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


        public Controller(double spawnRate, ulong startTime, Size sceneSize)
        {
            rnd = new Random();
            objects = new List<ColectableItem>();
            SpawnRate = spawnRate;
            Time = startTime;
            SceneSize = sceneSize;
            Points = 0;
            MinLifeTime = 1;
            MaxLifeTime = 5;
            MinSpriteSize = 10;
            MaxSpriteSize = 20;
        }

        public void spawnObject()
        {
            
        }

        public void destroyObject(ColectableItem obj)
        {
            objects.Remove(obj);
        }

        public void Update(double delta)
        {


        }

        public void mouseClick(Point mousePos)
        {
             
        }

        public void pointsIncrease(double pointsValue)
        {
            Points += pointsValue;
        }
    }
}
