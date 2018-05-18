using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public enum BatteryLevel : byte { Empty = 0, Low = 1, Medium = 2, Full = 3 };

    public class XBoxBattery
    {
        public event EventHandler<LevelChangeArgs> LevelChanged;

        private BatteryLevel level;
        public BatteryLevel Level
        {
            get { return level; }
            internal set
            {
                if (level != value)
                {
                    level = value;
                    OnLevelChanged(new LevelChangeArgs(level));
                }
            }
        }

        public XBoxBattery(BatteryLevel initialLevel = BatteryLevel.Empty)
        {
            level = initialLevel;
        }

        protected virtual void OnLevelChanged(LevelChangeArgs e)
        {
            LevelChanged?.Invoke(this, e);
        }
    }
}
