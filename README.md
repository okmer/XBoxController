# XBoxController
XBox 360 Controller library with sample application using SharpDX.XInput in C#.

```csharp
XBoxController controller = new XBoxController();

//Connection
controller.Connection.ValueChanged += (s, e) => Console.WriteLine($"Connection state: {e.Value}");

//Battery
controller.Battery.ValueChanged += (s, e) => Console.WriteLine($"Battery level: {e.Value}");

//Buttons
controller.A.ValueChanged += (s, e) => Console.WriteLine($"A state: {e.Value}");
controller.B.ValueChanged += (s, e) => Console.WriteLine($"B state: {e.Value}");

//Triggers
controller.LeftTrigger.ValueChanged += (s, e) => Console.WriteLine($"Left trigger position: {e.Value}");
controller.RightTrigger.ValueChanged += (s, e) => Console.WriteLine($"Right trigger position: {e.Value}");

//Thumbs
controller.LeftThumbstick.ValueChanged += (s, e) => Console.WriteLine($"Left thumb X: {e.Value.X}, Y: {e.Value.Y}");
controller.RightThumbstick.ValueChanged += (s, e) => Console.WriteLine($"Right thumb X: {e.Value.X}, Y: {e.Value.Y}");

//Rumble Left, Right
controller.LeftRumble.ValueChanged += (s, e) => Console.WriteLine($"Left rumble speed: {e.Value}");
controller.RightRumble.ValueChanged += (s, e) => Console.WriteLine($"Right rumble speed: {e.Value}");

//Rumble 0.25f speed for 500 milliseconds when the A or B button is pushed
controller.A.ValueChanged += (s, e) => controller.LeftRumble.Rumble(0.25f, 500);
controller.B.ValueChanged += (s, e) => controller.RightRumble.Rumble(0.25f, 500);

//Rumble at the speed of the trigger position
controller.LeftTrigger.ValueChanged += (s, e) => controller.LeftRumble.Rumble(e.Value);
controller.RightTrigger.ValueChanged += (s, e) => controller.RightRumble.Rumble(e.Value);

```

Note: A BUG in SharpDX.XInput ci-ci217, resulting in issues with the  left Thumb Stick, Left Trigger, and Right Trigger! Please stick to SharpDX.XInput v4.1.0-ci184 for now...

![Sample Application Screenshot](https://github.com/okmer/XBoxController/blob/master/SampleApplicationScreenshot.png)

![Steintje Controller Fun Screenshot](https://github.com/okmer/XBoxController/blob/TheSteintjeExperiment/SteintjeControllerFunScreenshot.jpg)
