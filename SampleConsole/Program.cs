using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            controller.Connection.StateChanged += (s, e) => Console.WriteLine($"Connection state: {e.State}");

            //Battery
            controller.Battery.LevelChanged += (s, e) => Console.WriteLine($"Battery level: {e.Level}");

            //Buttons A, B, X, Y
            controller.A.StateChanged += (s, e) => Console.WriteLine($"A state: {e.State}");
            controller.B.StateChanged += (s, e) => Console.WriteLine($"B state: {e.State}");
            controller.X.StateChanged += (s, e) => Console.WriteLine($"X state: {e.State}");
            controller.Y.StateChanged += (s, e) => Console.WriteLine($"Y state: {e.State}");

            //Buttons Start, Back
            controller.Start.StateChanged += (s, e) => Console.WriteLine($"Start state: {e.State}");
            controller.Back.StateChanged += (s, e) => Console.WriteLine($"Back state: {e.State}");

            //Buttons D-Pad Up, Down, Left, Right
            controller.Up.StateChanged += (s, e) => Console.WriteLine($"Up state: {e.State}");
            controller.Down.StateChanged += (s, e) => Console.WriteLine($"Down state: {e.State}");
            controller.Left.StateChanged += (s, e) => Console.WriteLine($"Left state: {e.State}");
            controller.Right.StateChanged += (s, e) => Console.WriteLine($"Right state: {e.State}");

            //Buttons Shoulder Left, Right
            controller.LeftShoulder.StateChanged += (s, e) => Console.WriteLine($"Left shoulder state: {e.State}");
            controller.RightShoulder.StateChanged += (s, e) => Console.WriteLine($"Right shoulder state: {e.State}");

            //Buttons Thumb Left, Right
            controller.LeftThumb.StateChanged += (s, e) => Console.WriteLine($"Left thumb state: {e.State}");
            controller.RightThumb.StateChanged += (s, e) => Console.WriteLine($"Right thumb state: {e.State}");

            //Trigger Position Left, Right 
            controller.LeftTrigger.PositionChanged += (s, e) => Console.WriteLine($"Left trigger position: {e.Position}");
            controller.RightTrigger.PositionChanged += (s, e) => Console.WriteLine($"Right trigger position: {e.Position}");

            //Thumb Positions Left, Right
            controller.LeftThumb.PositionsChanged += (s, e) => Console.WriteLine($"Left thumb X: {e.X}, Y: {e.Y}");
            controller.RightThumb.PositionsChanged += (s, e) => Console.WriteLine($"Right thumb X: {e.X}, Y: {e.Y}");

            //Rumble Left, Right
            controller.LeftRumble.SpeedChanged += (s, e) => Console.WriteLine($"Left rumble speed: {e.Speed}");
            controller.RightRumble.SpeedChanged += (s, e) => Console.WriteLine($"Right rumble speed: {e.Speed}");

            //Rumble for 500 milliseconds at 0.25f speed when the A or B button is pushed
            controller.A.StateChanged += (s, e) => controller.LeftRumble.Rumble(0.25f, 500);
            controller.B.StateChanged += (s, e) => controller.RightRumble.Rumble(0.25f, 500);

            //Rumble for 1000 milliseconds at 1.0f speed when the X or Y button is pushed
            controller.X.StateChanged += (s, e) => controller.LeftRumble.Rumble(1.0f, 1000);
            controller.Y.StateChanged += (s, e) => controller.RightRumble.Rumble(1.0f, 1000);

            //Wait on ENTER to exit...
            Console.ReadLine();
        }
    }
}
