namespace Com.Okmer.GameController
{
    public class LevelChangeArgs
    {
        public BatteryLevel Level { get; }

        public LevelChangeArgs(BatteryLevel level)
        {
            Level = level;
        }
    }
}