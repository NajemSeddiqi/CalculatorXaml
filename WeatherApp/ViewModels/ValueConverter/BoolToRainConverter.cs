using System;
using System.Globalization;
using System.Windows.Data;

namespace WeatherApp.ViewModels.ValueConverter
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isRaining = (bool)value;
            if (isRaining)
                return "Currently raining";

            return "Currently not raining";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (string)value == "Currently raining";
    }
}
