using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Com.Okmer.GameController.Helpers;

namespace Com.Okmer.GameController
{
    public class XBoxThumb : XBoxButton
    {
        private bool changed = false;

        public event EventHandler<PositionsChangeArgs> PositionsChanged;
        public event EventHandler<ThumbChangeArgs> ThumbChanged;

        public float DeadZone { get; set; } = 0.0f;

        private Vector2 positions;
        internal Vector2 Positions
        {
            get => positions;
            set
            {
                Vector2 v = value.DeadZoneCorrected(DeadZone);

                if (positions != v)
                {
                    positions = v;
                    OnPositionsChanged(new PositionsChangeArgs(X, Y));
                }
            }
        }


        public float X
        {
            get => Positions.X;
        }

        public float Y
        {
            get => Positions.Y;
        }

        public XBoxThumb(float deadZone = 0.0f, float initialX = 0.0f, float initialY = 0.0f, bool initialState = false) : base(initialState)
        {
            DeadZone = deadZone;
            Positions = new Vector2(initialX, initialY);
        }

        internal void SetThumb(float x, float y, bool state)
        {
            State = state;
            Positions = new Vector2(x, y);

            if (changed)
            {
                changed = false;
                OnThumbChanged(new ThumbChangeArgs(X, Y, State));
            }
        }

        protected virtual void OnPositionsChanged(PositionsChangeArgs e)
        {
            PositionsChanged?.Invoke(this, e);
        }

        protected virtual void OnThumbChanged(ThumbChangeArgs e)
        {
            ThumbChanged?.Invoke(this, e);
        }
    }
}
