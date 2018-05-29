using System;

using Com.Okmer.GameController;

namespace XBoxSampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            XBoxController controller = new XBoxController();

            Console.WriteLine("XBox 360 Controller (Press ENTER to exit...)");

            //Connection
            controller.Connection.ValueChanged += (s, e) => Console.WriteLine($"Connection state: {e.Value}");

            //Battery
            controller.Battery.ValueChanged += (s, e) => Console.WriteLine($"Battery level: {e.Value}");

            //Buttons A, B, X, Y
            controller.A.ValueChanged += (s, e) => Console.WriteLine($"A state: {e.Value}");
            controller.B.ValueChanged += (s, e) => Console.WriteLine($"B state: {e.Value}");
            controller.X.ValueChanged += (s, e) => Console.WriteLine($"X state: {e.Value}");
            controller.Y.ValueChanged += (s, e) => Console.WriteLine($"Y state: {e.Value}");

            //Buttons Start, Back
            controller.Start.ValueChanged += (s, e) => Console.WriteLine($"Start state: {e.Value}");
            controller.Back.ValueChanged += (s, e) => Console.WriteLine($"Back state: {e.Value}");

            //Buttons D-Pad Up, Down, Left, Right
            controller.Up.ValueChanged += (s, e) => Console.WriteLine($"Up state: {e.Value}");
            controller.Down.ValueChanged += (s, e) => Console.WriteLine($"Down state: {e.Value}");
            controller.Left.ValueChanged += (s, e) => Console.WriteLine($"Left state: {e.Value}");
            controller.Right.ValueChanged += (s, e) => Console.WriteLine($"Right state: {e.Value}");

            //Buttons Shoulder Left, Right
            controller.LeftShoulder.ValueChanged += (s, e) => Console.WriteLine($"Left shoulder state: {e.Value}");
            controller.RightShoulder.ValueChanged += (s, e) => Console.WriteLine($"Right shoulder state: {e.Value}");

            //Buttons Thumb Left, Right
            controller.LeftThumbclick.ValueChanged += (s, e) => Console.WriteLine($"Left thumb state: {e.Value}");
            controller.RightThumbclick.ValueChanged += (s, e) => Console.WriteLine($"Right thumb state: {e.Value}");

            //Trigger Position Left, Right 
            controller.LeftTrigger.ValueChanged += (s, e) => Console.WriteLine($"Left trigger position: {e.Value}");
            controller.RightTrigger.ValueChanged += (s, e) => Console.WriteLine($"Right trigger position: {e.Value}");

            //Thumb Positions Left, Right
            controller.LeftThumbstick.ValueChanged += (s, e) => Console.WriteLine($"Left thumb X: {e.Value.X}, Y: {e.Value.Y}");
            controller.RightThumbstick.ValueChanged += (s, e) => Console.WriteLine($"Right thumb X: {e.Value.X}, Y: {e.Value.Y}");

            //Rumble Left, Right
            controller.LeftRumble.ValueChanged += (s, e) => Console.WriteLine($"Left rumble speed: {e.Value}");
            controller.RightRumble.ValueChanged += (s, e) => Console.WriteLine($"Right rumble speed: {e.Value}");

            //Rumble 0.25f speed for 500 milliseconds when the A or B button is pushed
            controller.A.ValueChanged += (s, e) => controller.LeftRumble.Rumble(0.25f, 500);
            controller.B.ValueChanged += (s, e) => controller.RightRumble.Rumble(0.25f, 500);

            //Rumble at 1.0f speed for 1000 milliseconds when the X or Y button is pushed
            controller.X.ValueChanged += (s, e) => controller.LeftRumble.Rumble(1.0f, 1000);
            controller.Y.ValueChanged += (s, e) => controller.RightRumble.Rumble(1.0f, 1000);

            //Rumble at the speed of the trigger position
            controller.LeftTrigger.ValueChanged += (s, e) => controller.LeftRumble.Rumble(e.Value);
            controller.RightTrigger.ValueChanged += (s, e) => controller.RightRumble.Rumble(e.Value);

            //Wait on ENTER to exit...
            Console.ReadLine();
        }
    }
}
