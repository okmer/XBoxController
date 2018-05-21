using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Okmer.GameController.Helpers;

namespace Com.Okmer.GameController
{
    public class XBoxTrigger
    {
        public event EventHandler<PositionChangeArgs> PositionChanged;

        public float DeadZone { get; set; } = 0.0f;

        private float position;
        public float Position
        {
            get => position;
            internal set
            {
                float v = value.DeadZoneCorrected(DeadZone);

                if (position != v)
                {
                    position = v;
                    OnPositionChanged(new PositionChangeArgs(position));
                }
            }
        }

        public XBoxTrigger(float deadZone = 0.0f, float initialTrigger = 0.0f)
        {
            DeadZone = deadZone;
            position = initialTrigger;
        }

        protected virtual void OnPositionChanged(PositionChangeArgs e)
        {
            PositionChanged?.Invoke(this, e);
        }
    }
}
