using Com.Okmer.GameController.Helpers;

namespace Com.Okmer.GameController
{
    public class XBoxTrigger : XBoxComponent<float>
    {
        public float DeadZone { get; set; } = 0.0f;

        public override float Value
        {
            get => base.Value;
            internal set => base.Value = value.DeadZoneCorrected(DeadZone);
        }

        public XBoxTrigger(float deadZone = 0.0f, float initialValue = 0.0f) : base(initialValue)
        {
            DeadZone = deadZone;
        }
    }
}
