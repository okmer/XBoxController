using Com.Okmer.GameController.Helpers;
using SharpDX.XInput;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class XBoxController
    {
        public const float MinTrigger = 0.0f;
        public const float MaxTrigger = 1.0f;

        public const float MinThumb = -1.0f;
        public const float MaxThumb = 1.0f;

        private Controller controller;

        private Task fastPollTask;
        private Task slowPollTask;

        //Buttons
        public XBoxButton A { get; } = new XBoxButton();
        public XBoxButton B { get; } = new XBoxButton();
        public XBoxButton X { get; } = new XBoxButton();
        public XBoxButton Y { get; } = new XBoxButton();

        public XBoxButton LeftShoulder { get; } = new XBoxButton();
        public XBoxButton RightShoulder { get; } = new XBoxButton();

        public XBoxButton Start { get; } = new XBoxButton();
        public XBoxButton Back { get; } = new XBoxButton();

        //D-pad
        public XBoxButton Up { get; } = new XBoxButton();
        public XBoxButton Down { get; } = new XBoxButton();
        public XBoxButton Left { get; } = new XBoxButton();
        public XBoxButton Right { get; } = new XBoxButton();

        //Triggers
        public XBoxTrigger LeftTrigger { get; } = new XBoxTrigger(/*Gamepad.TriggerThreshold.RemapF(0, byte.MaxValue, 0.0f, TriggerMax)*/);
        public XBoxTrigger RightTrigger { get; } = new XBoxTrigger(/*Gamepad.TriggerThreshold.RemapF(0, byte.MaxValue, 0.0f, TriggerMax)*/);

        //Thumb sticks
        public XBoxThumb LeftThumb { get; } = new XBoxThumb(/*Gamepad.LeftThumbDeadZone.RemapF(0, short.MaxValue, 0.0f, ThumbMax)*/);
        public XBoxThumb RightThumb { get; } = new XBoxThumb(/*Gamepad.RightThumbDeadZone.RemapF(0, short.MaxValue, 0.0f, ThumbMax)*/);

        public XBoxBattery Battery { get; } = new XBoxBattery();

        public XBoxConnection Connection { get; } = new XBoxConnection();

        public XBoxController(int fastPollIntervalMilliseconds = 10, int slowPollIntervalMilliseconds = 1000)
        {
            controller = new Controller(UserIndex.One);

            fastPollTask = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(fastPollIntervalMilliseconds);
                    FastPoll();
                }
            });

            slowPollTask = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(slowPollIntervalMilliseconds);
                    SlowPoll();
                }
            });
        }

        private void FastPoll()
        {
            if (!controller.IsConnected)
                return;

            var gamepad = controller.GetState().Gamepad;

            A.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            B.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            X.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            Y.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);

            LeftShoulder.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            RightShoulder.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);

            Start.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
            Back.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);

            Up.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            Down.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            Left.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
            Right.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);

            LeftThumb.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
            RightThumb.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);

            LeftTrigger.Position = gamepad.LeftTrigger.RemapF(byte.MinValue, byte.MaxValue, MinTrigger, MaxTrigger);
            RightTrigger.Position = gamepad.RightTrigger.RemapF(byte.MinValue, byte.MaxValue, MinTrigger, MaxTrigger);

            float leftPositionX = gamepad.LeftThumbX.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb);
            float leftPositionY = gamepad.LeftThumbY.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb);
            LeftThumb.SetPositions(leftPositionX, leftPositionY);

            float rightPositionX = gamepad.RightThumbX.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb);
            float rightPositionY = gamepad.RightThumbY.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb);
            RightThumb.SetPositions(rightPositionX, rightPositionY);
        }

        private void SlowPoll()
        {
            Connection.State = controller.IsConnected;

            Battery.Level = controller.IsConnected ? (BatteryLevel)controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryLevel : BatteryLevel.Empty;
        }
    }
}
