using System;
using System.Globalization;
using System.Windows.Data;
using System.Numerics;
using Com.Okmer.GameController;
using System.Windows.Media;

namespace Com.Okmer.XBoxSampleApplication
{
    public class BatteryLevelValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = new SolidColorBrush(Colors.DarkGray);
            BatteryLevel parameterValue;

            if (value != null && targetType == typeof(Brush) &&
                BatteryLevel.TryParse((string)parameter, out parameterValue))
            {
                BatteryLevel v = (BatteryLevel)value;

                result = new SolidColorBrush(v >= parameterValue ? Colors.Green : Colors.DarkGray);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
