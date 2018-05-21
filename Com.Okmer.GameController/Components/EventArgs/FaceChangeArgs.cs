using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class FaceChangeArgs : EventArgs
    {
        public bool AState { get; }
        public bool BState { get; }
        public bool XState { get; }
        public bool YState { get; }

        public FaceChangeArgs(bool aState, bool bState, bool xState, bool yState)
        {
            AState = aState;
            BState = bState;
            XState = xState;
            YState = yState;
        }
    }
}