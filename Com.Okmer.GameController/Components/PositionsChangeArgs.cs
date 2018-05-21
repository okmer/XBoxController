using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class PositionsChangeArgs : StateChangeArgs
    {
        public float X { get; }
        public float Y { get; }

        public PositionsChangeArgs(float x, float y, bool state) : base(state)
        {
            X = x;
            Y = y;
        }
    }
}
