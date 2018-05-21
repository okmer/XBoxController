# XBoxController
XBox 360 Controller library with sample application using SharpDX.XInput in C#.

```csharp
XBoxController controller = new XBoxController();

//Connection
controller.Connection.StateChanged += (s, e) => Console.WriteLine($"Connection state: {e.State}");

//Battery
controller.Battery.LevelChanged += (s, e) => Console.WriteLine($"Battery level: {e.Level}");

//Buttons
controller.A.StateChanged += (s, e) => Console.WriteLine($"A state: {e.State}");
controller.B.StateChanged += (s, e) => Console.WriteLine($"B state: {e.State}");

//Triggers
controller.LeftTrigger.PositionChanged += (s, e) => Console.WriteLine($"Left trigger position: {e.Position}");
controller.RightTrigger.PositionChanged += (s, e) => Console.WriteLine($"Right trigger position: {e.Position}");

//Thumbs
controller.LeftThumb.PositionsChanged += (s, e) => Console.WriteLine($"Left thumb X: {e.X}, Y: {e.Y}");
controller.RightThumb.PositionsChanged += (s, e) => Console.WriteLine($"Right thumb X: {e.X}, Y: {e.Y}");

//Rumble Left, Right
controller.LeftRumble.SpeedChanged += (s, e) => Console.WriteLine($"Left rumble speed: {e.Speed}");
controller.RightRumble.SpeedChanged += (s, e) => Console.WriteLine($"Right rumble speed: {e.Speed}");

//Rumble for 500 milliseconds at 0.25f speed when the A or B button is pushed
controller.A.StateChanged += (s, e) => controller.LeftRumble.Rumble(0.25f, 500);
controller.B.StateChanged += (s, e) => controller.RightRumble.Rumble(0.25f, 500);

```

Note: A BUG in SharpDX.XInput ci-ci217, resulting in issues with the  left Thumb Stick, Left Trigger, and Right Trigger! Please stick to SharpDX.XInput v4.1.0-ci184 for now...

![Sample Application Screenshot](https://github.com/okmer/XBoxController/blob/master/SampleApplicationScreenshot.png)
