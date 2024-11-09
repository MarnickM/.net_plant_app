using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace plantDration.Converters
{
    public class DateTimeToWaterStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if (date == DateTime.MinValue)
                {
                    return "💧 Not watered yet";  // Add emoji for "Not watered yet"
                }
                else
                {
                    return $"💧 {date:dd/MM/yyyy}";  // Add emoji and format date in European format
                }
            }
            return "💧 Not watered yet";  // Fallback text
        }

        // this must be added in order to use this interface but we don't use it in our app
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
