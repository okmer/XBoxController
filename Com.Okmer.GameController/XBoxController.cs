using Com.Okmer.GameController.Helpers;
using SharpDX.XInput;
using System.Threading.Tasks;

namespace Com.Okmer.GameController
{
    public class XBoxController
    {
        private Task fastPollTask;
        private Task slowPollTask;

        public const float MinTrigger = 0.0f;
        public const float MaxTrigger = 1.0f;

        public const float MinThumb = -1.0f;
        public const float MaxThumb = 1.0f;

        public const float MinRumble = 0.0f;
        public const float MaxRumble = 1.0f;

        private Controller controller;
        private Vibration vibration = new Vibration();

        //Buttons
        public XBoxFace Face { get; } = new XBoxFace();
        public XBoxButton A { get => Face.A; }
        public XBoxButton B { get => Face.B; }
        public XBoxButton X { get => Face.X; }
        public XBoxButton Y { get => Face.Y; }

        public XBoxButton LeftShoulder { get; } = new XBoxButton();
        public XBoxButton RightShoulder { get; } = new XBoxButton();

        public XBoxButton Start { get; } = new XBoxButton();
        public XBoxButton Back { get; } = new XBoxButton();

        //D-pad
        public XBoxDPad DPad { get; } = new XBoxDPad();
        public XBoxButton Up { get => DPad.Up; }
        public XBoxButton Down { get => DPad.Down; }
        public XBoxButton Left { get => DPad.Left; }
        public XBoxButton Right { get => DPad.Right; }

        //Triggers
        public XBoxTrigger LeftTrigger { get; } = new XBoxTrigger(/*Gamepad.TriggerThreshold.RemapF(0, byte.MaxValue, 0.0f, TriggerMax)*/);
        public XBoxTrigger RightTrigger { get; } = new XBoxTrigger(/*Gamepad.TriggerThreshold.RemapF(0, byte.MaxValue, 0.0f, TriggerMax)*/);

        //Thumb sticks
        public XBoxThumb LeftThumb { get; } = new XBoxThumb(/*Gamepad.LeftThumbDeadZone.RemapF(0, short.MaxValue, 0.0f, ThumbMax)*/);
        public XBoxThumb RightThumb { get; } = new XBoxThumb(/*Gamepad.RightThumbDeadZone.RemapF(0, short.MaxValue, 0.0f, ThumbMax)*/);

        public XBoxBattery Battery { get; } = new XBoxBattery();

        public XBoxConnection Connection { get; } = new XBoxConnection();

        public XBoxRumble LeftRumble { get; } = new XBoxRumble();
        public XBoxRumble RightRumble { get; } = new XBoxRumble();

        public XBoxController(int fastPollIntervalMilliseconds = 10, int slowPollIntervalMilliseconds = 1000)
        {
            controller = new Controller(UserIndex.One);

            //Forward changed left rumble speed to the controller 
            LeftRumble.SpeedChanged += (s, e) =>
            {
                if (!controller.IsConnected)
                    return;

                vibration.LeftMotorSpeed = (ushort)e.Speed.RemapF(MinRumble, MaxRumble, ushort.MinValue, ushort.MaxValue);
                controller.SetVibration(vibration);
            };

            //Forward changed right rumble speed to the controller
            RightRumble.SpeedChanged += (s, e) =>
            {
                if (!controller.IsConnected)
                    return;

                vibration.RightMotorSpeed = (ushort)e.Speed.RemapF(MinRumble, MaxRumble, ushort.MinValue, ushort.MaxValue);
                controller.SetVibration(vibration);
            };

            //Fast poll loop
            fastPollTask = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(fastPollIntervalMilliseconds);
                    FastPoll();
                }
            });

            //Slow poll loop
            slowPollTask = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(slowPollIntervalMilliseconds);
                    SlowPoll();
                }
            });
        }

        /// <summary>
        /// The fast poll method to readout the button states, trigger positions, thumb stick states and positions.
        /// </summary>
        private void FastPoll()
        {
            if (!controller.IsConnected)
                return;

            var gamepad = controller.GetState().Gamepad;

            Face.SetFace(gamepad.Buttons.HasFlag(GamepadButtonFlags.A),
                         gamepad.Buttons.HasFlag(GamepadButtonFlags.B),
                         gamepad.Buttons.HasFlag(GamepadButtonFlags.X),
                         gamepad.Buttons.HasFlag(GamepadButtonFlags.Y));

            LeftShoulder.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            RightShoulder.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);

            Start.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
            Back.State = gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);

            DPad.SetDPad(gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp),
                         gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown),
                         gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft),
                         gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight));

            LeftTrigger.Position = gamepad.LeftTrigger.RemapF(byte.MinValue, byte.MaxValue, MinTrigger, MaxTrigger);
            RightTrigger.Position = gamepad.RightTrigger.RemapF(byte.MinValue, byte.MaxValue, MinTrigger, MaxTrigger);

            LeftThumb.SetThumb(gamepad.LeftThumbX.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb),
                               gamepad.LeftThumbY.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb),
                               gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb));

            RightThumb.SetThumb(gamepad.RightThumbX.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb),
                                gamepad.RightThumbY.RemapF(short.MinValue, short.MaxValue, MinThumb, MaxThumb),
                                gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb));
        }

        /// <summary>
        /// The slow poll method to readout the connection state and battery level.
        /// </summary>
        private void SlowPoll()
        {
            Connection.State = controller.IsConnected;

            Battery.Level = controller.IsConnected ? (BatteryLevel)controller.GetBatteryInformation(BatteryDeviceType.Gamepad).BatteryLevel : BatteryLevel.Empty;
        }
    }
}
