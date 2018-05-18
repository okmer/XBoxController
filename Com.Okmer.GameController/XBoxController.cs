using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using SharpDX.XInput;

using Com.Okmer.GameController.Helpers;

namespace Com.Okmer.GameController
{
    public class XBoxController
    {
        private Controller controller;

        private Task pollTask;

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
        public XBoxTrigger LeftTrigger { get; } = new XBoxTrigger(/*Gamepad.TriggerThreshold.RemapF(0, byte.MaxValue, 0.0f, 1.0f)*/);
        public XBoxTrigger RightTrigger { get; } = new XBoxTrigger(/*Gamepad.TriggerThreshold.RemapF(0, byte.MaxValue, 0.0f, 1.0f)*/);

        //Thumb sticks
        public XBoxThumb LeftThumb { get; } = new XBoxThumb(/*Gamepad.LeftThumbDeadZone.RemapF(0, short.MaxValue, 0.0f, 1.0f)*/);
        public XBoxThumb RightThumb { get; } = new XBoxThumb(/*Gamepad.RightThumbDeadZone.RemapF(0, short.MaxValue, 0.0f, 1.0f)*/);

        public XBoxController(int pollIntervalMilliseconds = 10)
        {
            controller = new Controller(UserIndex.One);

            pollTask = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(pollIntervalMilliseconds);
                    Update();
                }

            });
        }

        private void Update()
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

            LeftTrigger.Position = gamepad.LeftTrigger.RemapF(byte.MinValue, byte.MaxValue, 0.0f, 1.0f);
            RightTrigger.Position = gamepad.RightTrigger.RemapF(byte.MinValue, byte.MaxValue, 0.0f, 1.0f);

            float leftPositionX = gamepad.LeftThumbX.RemapF(short.MinValue, short.MaxValue, -1.0f, 1.0f);
            float leftPositionY = gamepad.LeftThumbY.RemapF(short.MinValue, short.MaxValue, -1.0f, 1.0f);
            LeftThumb.SetPositions(leftPositionX, leftPositionY);

            float rightPositionX = gamepad.RightThumbX.RemapF(short.MinValue, short.MaxValue, -1.0f, 1.0f);
            float rightPositionY = gamepad.RightThumbY.RemapF(short.MinValue, short.MaxValue, -1.0f, 1.0f);
            RightThumb.SetPositions(rightPositionX, rightPositionY);
        }
    }
}
