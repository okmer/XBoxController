using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class PositionChangeArgs : EventArgs
    {
        public float Position { get; }

        public PositionChangeArgs(float position)
        {
            Position = position;
        }
    }
}
