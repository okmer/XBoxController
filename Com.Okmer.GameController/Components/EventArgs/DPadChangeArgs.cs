using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class DPadChangeArgs : EventArgs
    {
        public bool UpState { get; }
        public bool DownState { get; }
        public bool LeftState { get; }
        public bool RightState { get; }

        public DPadChangeArgs(bool upState, bool downState, bool leftState, bool rightState)
        {
            UpState = upState;
            DownState = downState;
            LeftState = leftState;
            RightState = rightState;
        }
    }
}