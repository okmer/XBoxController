using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class XBoxButton
    {
        public event EventHandler<StateChangeArgs> StateChanged;

        private bool state;
        public bool State
        {
            get { return state; }
            internal set
            {
                if (state != value)
                {
                    state = value;
                    OnStateChanged(new StateChangeArgs(state));
                }
            }
        }

        public XBoxButton(bool initialState = false)
        {
            state = initialState;
        }

        protected virtual void OnStateChanged(StateChangeArgs e)
        {
            StateChanged?.Invoke(this, e);
        }
    }
}
