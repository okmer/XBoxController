using Com.Okmer.GameController;
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

namespace SteintjeControllerFun
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

            Controller.A.ValueChanged += (s, e) => { if (e.Value) PlaySound(@"Assets\cow-moo3.wav"); };

            Controller.LeftThumbstick.ValueChanged += (s, e) => guiDisp.Invoke(() =>
            {
                Cow.Margin = new Thickness(this.ActualWidth * e.Value.X - 0.5 * Cow.Width, 30 * Math.Sin(0.01 * this.ActualWidth * e.Value.X), 0.0, 0.0);
            });

            Controller.LeftTrigger.ValueChanged += (s, e) => guiDisp.Invoke(() =>
            {
                double HalfPi = 0.5 * Math.PI;

                Sun.Margin = new Thickness(0.5 * this.ActualWidth * e.Value,
                                           -this.ActualHeight * Math.Sin(e.Value * HalfPi),
                                           0.0, 
                                           0.0);
            });

            Controller.RightTrigger.ValueChanged += (s, e) => guiDisp.Invoke(() =>
            {
                double HalfPi = 0.5 * Math.PI;

                Moon.Margin = new Thickness(0.0,
                                           -this.ActualHeight * Math.Sin(e.Value * HalfPi),
                                           0.5 * this.ActualWidth * e.Value,
                                           0.0);
            });
        }

        private void PlaySound(string soundFile)
        {
            var player = new MediaPlayer();
            var uri = new Uri($"{soundFile}", UriKind.RelativeOrAbsolute);

            player.Open(uri);
            player.Play();
        }
    }
}
