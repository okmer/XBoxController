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
            controller.Connection.StateChanged += (s, e) => guiDisp.Invoke(() => { ConnectedBorder.Background = new SolidColorBrush(e.State ? Colors.Green : Colors.DarkRed); });

            //Battery
            controller.Battery.LevelChanged += (s, e) => guiDisp.Invoke(() => 
            {
                Bat1Rectangle.Fill = new SolidColorBrush(e.Level > BatteryLevel.Empty ? Colors.Green : Colors.DarkGray);
                Bat2Rectangle.Fill = new SolidColorBrush(e.Level > BatteryLevel.Low ? Colors.Green : Colors.DarkGray);
                Bat3Rectangle.Fill = new SolidColorBrush(e.Level > BatteryLevel.Medium ? Colors.Green : Colors.DarkGray);
            });

            //Buttons A, B, X, Y
            controller.A.StateChanged += (s, e) => guiDisp.Invoke(() => { ACircle.Fill = new SolidColorBrush(e.State ? Colors.Green : Colors.DarkGreen); });
            controller.B.StateChanged += (s, e) => guiDisp.Invoke(() => { BCircle.Fill = new SolidColorBrush(e.State ? Colors.Red : Colors.DarkRed); });
            controller.X.StateChanged += (s, e) => guiDisp.Invoke(() => { XCircle.Fill = new SolidColorBrush(e.State ? Colors.Blue : Colors.DarkBlue); });
            controller.Y.StateChanged += (s, e) => guiDisp.Invoke(() => { YCircle.Fill = new SolidColorBrush(e.State ? Colors.Orange : Colors.DarkOrange); });

            //Buttons Start, Back
            controller.Start.StateChanged += (s, e) => guiDisp.Invoke(() => { StartCircle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });
            controller.Back.StateChanged += (s, e) => guiDisp.Invoke(() => { BackCircle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });

            //Buttons D-Pad Up, Down, Left, Right
            controller.Up.StateChanged += (s, e) => guiDisp.Invoke(() => { UpRectangle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });
            controller.Down.StateChanged += (s, e) => guiDisp.Invoke(() => { DownRectangle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });
            controller.Left.StateChanged += (s, e) => guiDisp.Invoke(() => { LeftRectangle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });
            controller.Right.StateChanged += (s, e) => guiDisp.Invoke(() => { RightRectangle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });

            //Buttons Shoulder Left, Right
            controller.LeftShoulder.StateChanged += (s, e) => guiDisp.Invoke(() => { LeftShoulderRectangle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });
            controller.RightShoulder.StateChanged += (s, e) => guiDisp.Invoke(() => { RightShoulderRectangle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });

            //Buttons Thumb Left, Right
            controller.LeftThumb.StateChanged += (s, e) => guiDisp.Invoke(() => { LeftThumbCircle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });
            controller.RightThumb.StateChanged += (s, e) => guiDisp.Invoke(() => { RightThumbCircle.Fill = new SolidColorBrush(e.State ? Colors.LightGray : Colors.DarkGray); });

            //Trigger Position Left, Right 
            controller.LeftTrigger.PositionChanged += (s, e) => guiDisp.Invoke(() => { LeftTrigger.Value = e.Position; });
            controller.RightTrigger.PositionChanged += (s, e) => guiDisp.Invoke(() => { RightTrigger.Value = e.Position; });

            //Thumb Positions Left, Right
            controller.LeftThumb.PositionsChanged += (s, e) => guiDisp.Invoke(() => { LeftThumbPositionsCircle.Margin = new Thickness(100.0 * e.X, -100.0 * e.Y, 0.0, 0.0); });
            controller.RightThumb.PositionsChanged += (s, e) => guiDisp.Invoke(() => { RightThumbPositionsCircle.Margin = new Thickness(100.0 * e.X, -100.0 * e.Y, 0.0, 0.0); });
        }

        private void LeftRumble_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            controller.LeftRumble.Speed = (float)e.NewValue;
        }

        private void RightRumble_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            controller.RightRumble.Speed = (float)e.NewValue;
        }
    }
}
