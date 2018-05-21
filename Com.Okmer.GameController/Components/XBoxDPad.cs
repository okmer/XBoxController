using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class XBoxDPad
    {
        private bool changed = false;

        public event EventHandler<DPadChangeArgs> DPadChanged;

        //D-pad
        public XBoxButton Up { get; } = new XBoxButton();
        public XBoxButton Down { get; } = new XBoxButton();
        public XBoxButton Left { get; } = new XBoxButton();
        public XBoxButton Right { get; } = new XBoxButton();

        public XBoxDPad(bool initialState = false)
        {
            Up.StateChanged += (s, e) => changed = true;
            Down.StateChanged += (s, e) => changed = true;
            Left.StateChanged += (s, e) => changed = true;
            Right.StateChanged += (s, e) => changed = true;
        }

        internal void SetDPad(bool upState, bool downState, bool leftState, bool rightState)
        {
            Up.State = upState;
            Down.State = downState;
            Left.State = leftState;
            Right.State = rightState;

            if (changed)
            {
                changed = false;
                OnDPadChanged(new DPadChangeArgs(Up.State, Down.State, Left.State, Right.State));
            }
        }

        protected virtual void OnDPadChanged(DPadChangeArgs e)
        {
            DPadChanged?.Invoke(this, e);
        }
    }
}
