using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class XBoxFace
    {
        private bool changed = false;

        public event EventHandler<FaceChangeArgs> FaceChanged;

        //D-pad
        public XBoxButton A { get; } = new XBoxButton();
        public XBoxButton B { get; } = new XBoxButton();
        public XBoxButton X { get; } = new XBoxButton();
        public XBoxButton Y { get; } = new XBoxButton();

        public XBoxFace(bool initialState = false)
        {
            A.StateChanged += (s, e) => changed = true;
            B.StateChanged += (s, e) => changed = true;
            X.StateChanged += (s, e) => changed = true;
            Y.StateChanged += (s, e) => changed = true;
        }

        internal void SetFace(bool aState, bool bState, bool xState, bool yState)
        {
            A.State = aState;
            B.State = bState;
            X.State = xState;
            Y.State = yState;

            if (changed)
            {
                changed = false;
                OnFaceChanged(new FaceChangeArgs(A.State, B.State, X.State, Y.State));
            }
        }

        protected virtual void OnFaceChanged(FaceChangeArgs e)
        {
            FaceChanged?.Invoke(this, e);
        }
    }
}
