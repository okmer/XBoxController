using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class PositionsChangeArgs : EventArgs
    {
        public float X { get; }
        public float Y { get; }

        public PositionsChangeArgs(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
