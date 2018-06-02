using System;
using System.Globalization;
using System.Windows.Data;
using System.Numerics;
using System.Windows;

namespace SteintjeControllerFun.Converters
{
    public class ThicknessVerticalValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = new Thickness(0.0, 0.0, 0.0, 0.0);
            float parameterValue;

            if (value != null && targetType == typeof(Thickness) &&
                float.TryParse((string)parameter,
                NumberStyles.Float, culture, out parameterValue))
            {
                Vector2 v = (Vector2)value;

                float mx = parameterValue * v.X;
                float my = (float)Math.Sin(mx) * 10.0f;

                result = new Thickness(mx, my, 0.0, 0.0);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
