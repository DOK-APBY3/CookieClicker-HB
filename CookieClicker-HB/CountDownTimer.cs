using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    public class CountDownTimer
    {
        private double _targetTime;

        public double TargetTime
        {
            get { return _targetTime; }
            set { _targetTime = value; }
        }

        public double GetTime()
        {
            return TargetTime;
        }

        public void update(double delta)
        {
            if (TargetTime > 0)
            {
                TargetTime -= delta;

            }
        }
    }
}
