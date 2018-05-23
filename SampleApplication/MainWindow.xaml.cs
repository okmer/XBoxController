using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Com.Okmer.GameController;

namespace XBoxControllerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XBoxController controller = new XBoxController();

        public MainWindow()
        {
            InitializeComponent();

            var guiDisp = Application.Current.Dispatcher;

            //Connection
            controller.Connection.ValueChanged += (s, e) => guiDisp.Invoke(() => { ConnectedBorder.Background = new SolidColorBrush(e.Value ? Colors.Green : Colors.DarkRed); });

            //Battery
            controller.Battery.ValueChanged += (s, e) => guiDisp.Invoke(() =>
            {
                Bat1Rectangle.Fill = new SolidColorBrush(e.Value > BatteryLevel.Empty ? Colors.Green : Colors.DarkGray);
                Bat2Rectangle.Fill = new SolidColorBrush(e.Value > BatteryLevel.Low ? Colors.Green : Colors.DarkGray);
                Bat3Rectangle.Fill = new SolidColorBrush(e.Value > BatteryLevel.Medium ? Colors.Green : Colors.DarkGray);
            });

            //Buttons A, B, X, Y
            controller.A.ValueChanged += (s, e) => guiDisp.Invoke(() => { ACircle.Fill = new SolidColorBrush(e.Value ? Colors.Green : Colors.DarkGreen); });
            controller.B.ValueChanged += (s, e) => guiDisp.Invoke(() => { BCircle.Fill = new SolidColorBrush(e.Value ? Colors.Red : Colors.DarkRed); });
            controller.X.ValueChanged += (s, e) => guiDisp.Invoke(() => { XCircle.Fill = new SolidColorBrush(e.Value ? Colors.Blue : Colors.DarkBlue); });
            controller.Y.ValueChanged += (s, e) => guiDisp.Invoke(() => { YCircle.Fill = new SolidColorBrush(e.Value ? Colors.Orange : Colors.DarkOrange); });

            //Buttons Start, Back
            controller.Start.ValueChanged += (s, e) => guiDisp.Invoke(() => { StartCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            controller.Back.ValueChanged += (s, e) => guiDisp.Invoke(() => { BackCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Buttons D-Pad Up, Down, Left, Right
            controller.Up.ValueChanged += (s, e) => guiDisp.Invoke(() => { UpRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            controller.Down.ValueChanged += (s, e) => guiDisp.Invoke(() => { DownRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            controller.Left.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            controller.Right.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Buttons Shoulder Left, Right
            controller.LeftShoulder.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftShoulderRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            controller.RightShoulder.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightShoulderRectangle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Buttons Thumb Left, Right
            controller.LeftThumbclick.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftThumbCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });
            controller.RightThumbclick.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightThumbCircle.Fill = new SolidColorBrush(e.Value ? Colors.LightGray : Colors.DarkGray); });

            //Trigger Position Left, Right 
            controller.LeftTrigger.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftTrigger.Value = e.Value; });
            controller.RightTrigger.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightTrigger.Value = e.Value; });

            //Thumb Positions Left, Right
            controller.LeftThumbstick.ValueChanged += (s, e) => guiDisp.Invoke(() => { LeftThumbPositionsCircle.Margin = new Thickness(100.0 * e.Value.X, -100.0 * e.Value.Y, 0.0, 0.0); });
            controller.RightThumbstick.ValueChanged += (s, e) => guiDisp.Invoke(() => { RightThumbPositionsCircle.Margin = new Thickness(100.0 * e.Value.X, -100.0 * e.Value.Y, 0.0, 0.0); });
        }

        private void LeftRumble_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            controller.LeftRumble.Rumble((float)e.NewValue);
        }

        private void RightRumble_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            controller.RightRumble.Rumble((float)e.NewValue);
        }
    }
}
