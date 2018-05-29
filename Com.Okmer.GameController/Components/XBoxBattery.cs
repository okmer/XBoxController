namespace Com.Okmer.GameController
{
    public enum BatteryLevel : byte { Empty = 0, Low = 1, Medium = 2, Full = 3 };

    public class XBoxBattery : XBoxComponent<BatteryLevel>
    {
        public XBoxBattery(BatteryLevel initialLevel = BatteryLevel.Empty) : base(initialLevel) { }
    }
}
