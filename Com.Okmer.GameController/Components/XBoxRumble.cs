using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class XBoxRumble
    {
        public event EventHandler<SpeedChangeArgs> SpeedChanged;

        private float speed;
        public float Speed
        {
            get { return speed; }
            set
            {
                if (speed != value)
                {
                    speed = value;
                    OnStateChanged(new SpeedChangeArgs(speed));
                }
            }
        }

        public XBoxRumble(float initialSpeed = 0.0f)
        {
            speed = initialSpeed;
        }

        protected virtual void OnStateChanged(SpeedChangeArgs e)
        {
            SpeedChanged?.Invoke(this, e);
        }

        public void Rumble(float speed, int timeInMilliseconds)
        {
            Speed = speed;
            Task.Delay(timeInMilliseconds).ContinueWith(t => Speed = 0.0f);
        }
    }
}
