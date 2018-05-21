using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class SpeedChangeArgs : EventArgs
    {
        public float Speed { get; }

        public SpeedChangeArgs(float speed)
        {
            Speed = speed;
        }
    }
}
