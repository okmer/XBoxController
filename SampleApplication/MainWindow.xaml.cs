using System.Windows;
using System.Windows.Media;

using Com.Okmer.GameController;

namespace XBoxControllerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public XBoxController Controller { get; } = new XBoxController();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = Controller;

            var guiDisp = Application.Current.Dispatcher;

            //Connection
            Controller.Connection.ValueChanged += (s, e) => guiDisp.Invoke(() => { ConnectedBorder.Background = new SolidColorBrush(e.Value ? Colors.Green : Colors.DarkRed); });

            //Battery
            Controller.Battery.ValueChanged += (s, e) => guiDisp.Invoke(() =>
            {
                Bat1Rectangle.Fill = new SolidColorBrush(e.Value > BatteryLevel.Empty ? Colors.Green : Colors.DarkGray);
                Bat2Rectangle.Fill = new SolidColorBrush(e.Value > BatteryLevel.Low ? Colors.Green : Colors.DarkGray);
                Bat3Rectangle.Fill = new SolidColorBrush(e.Value > BatteryLevel.Medium ? Colors.Green : Colors.DarkGray);
            });

            //Buttons A, B, X, Y
            //Controller.A.ValueChanged += (s, e) => guiDisp.Invoke(() => { ACircle.Fill = new SolidColorBrush(e.Value ? Colors.Green : Colors.DarkGreen); });
            //Controller.B.ValueChanged += (s, e) => guiDisp.Invoke(() => { BCircle.Fill = new SolidColorBrush(e.Value ? Colors.Red : Colors.DarkRed); });
            //Controller.X.ValueChanged += (s, e) => guiDisp.Invoke(() => { XCircle.Fill = new SolidColorBrush(e.Value ? Colors.Blue : Colors.DarkBlue); });
            //Controller.Y.ValueChanged += (s, e) => guiDisp.Invoke(() => { YCircle.Fill = new SolidColorBrush(e.Value ? Colors.Orange : Colors.DarkOrange); });

            //Buttons Start, Back
            //Controller.Start.ValueChanged += (s, e) => guiDisp.Invoke(() => { StartCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            //Controller.Back.ValueChanged += (s, e) => guiDisp.Invoke(() => { BackCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Buttons D-Pad Up, Down, Left, Right
            //Controller.Up.ValueChanged += (s, e) => guiDisp.Invoke(() => { UpRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            //Controller.Down.ValueChanged += (s, e) => guiDisp.Invoke(() => { DownRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            //Controller.Left.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            //Controller.Right.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Buttons Shoulder Left, Right
            //Controller.LeftShoulder.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftShoulderRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            //Controller.RightShoulder.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightShoulderRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Buttons Thumb Left, Right
            //Controller.LeftThumbclick.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftThumbCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            //Controller.RightThumbclick.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightThumbCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Trigger Position Left, Right 
            //Controller.LeftTrigger.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftTrigger.Value = e.Value; });
            //Controller.RightTrigger.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightTrigger.Value = e.Value; });

            //Thumb Positions Left, Right
            Controller.LeftThumbstick.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftThumbPositionsCircle.Margin = new Thickness(100.0 * e.Value.X, -100.0 * e.Value.Y, 0.0, 0.0); });
            Controller.RightThumbstick.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightThumbPositionsCircle.Margin = new Thickness(100.0 * e.Value.X, -100.0 * e.Value.Y, 0.0, 0.0); });
        }

        private void LeftRumble_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Controller.LeftRumble.Rumble((float)e.NewValue);
        }

        private void RightRumble_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Controller.RightRumble.Rumble((float)e.NewValue);
        }
    }
}
