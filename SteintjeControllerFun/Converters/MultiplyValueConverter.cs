using System;
using System.Globalization;
using System.Windows.Data;

namespace SteintjeControllerFun.Converters
{
    public class MultiplyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = value;
            float parameterValue = 1.0f;

            if (value != null && (targetType == typeof(float) || targetType == typeof(double)) &&
                float.TryParse((string)parameter,
                NumberStyles.Float, culture, out parameterValue))
            {
                result = parameterValue * System.Convert.ToSingle(value);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
