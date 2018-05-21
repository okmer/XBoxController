using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class ThumbChangeArgs : EventArgs
    {
        public float X { get; }
        public float Y { get; }
        public bool State { get; }

        public ThumbChangeArgs(float x, float y, bool state)
        {
            X = x;
            Y = y;
            State = state;
        }
    }
}
