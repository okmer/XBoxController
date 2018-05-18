using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class StateChangeArgs : EventArgs
    {
        public bool State { get; }

        public StateChangeArgs(bool state)
        {
            State = state;
        }
    }
}
