using System;

namespace Com.Okmer.GameController
{
    public class LevelChangeArgs : EventArgs
    {
        public BatteryLevel Level { get; }

        public LevelChangeArgs(BatteryLevel level)
        {
            Level = level;
        }
    }
}