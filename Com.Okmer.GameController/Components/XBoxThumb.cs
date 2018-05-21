using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Okmer.GameController.Helpers;

namespace Com.Okmer.GameController
{
    public class XBoxThumb : XBoxButton
    {
        public event EventHandler<PositionsChangeArgs> PositionsChanged;

        public float DeadZone { get; set; } = 0.0f;

        private float x;
        public float X
        {
            get { return x; }
            internal set
            {
                float v = value.DeadZoneCorrected(DeadZone);

                if (x != v)
                {
                    x = v;
                    OnPositionsChanged(new PositionsChangeArgs(x, y, State));
                }
            }
        }

        private float y;
        public float Y
        {
            get { return y; }
            internal set
            {
                float v = value.DeadZoneCorrected(DeadZone);

                if (y != v)
                {
                    y = v;
                    OnPositionsChanged(new PositionsChangeArgs(x, y, State));
                }
            }
        }

        internal void SetPositions(float positionX, float positionY)
        {
            positionX = positionX.DeadZoneCorrected(DeadZone);
            positionY = positionY.DeadZoneCorrected(DeadZone);

            if (x != positionX || y != positionY)
            {
                x = positionX;
                y = positionY;
                OnPositionsChanged(new PositionsChangeArgs(x, y, State));
            }

        }

        public XBoxThumb(float deadZone = 0.0f, float initialX = 0.0f, float initialY = 0.0f, bool initialState = false) : base(initialState)
        {
            DeadZone = deadZone;
            x = initialX;
            y = initialY;
        }

        protected virtual void OnPositionsChanged(PositionsChangeArgs e)
        {
            PositionsChanged?.Invoke(this, e);
        }
    }
}
