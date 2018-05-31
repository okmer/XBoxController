using System;
using System.Globalization;
using System.Windows.Data;

namespace Com.Okmer.XBoxSampleApplication
{
    public class MultiplyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = value;
            float parameterValue;

            if (value != null && targetType == typeof(float) &&
                float.TryParse((string)parameter,
                NumberStyles.Float, culture, out parameterValue))
            {
                result = (float)value + parameterValue;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
