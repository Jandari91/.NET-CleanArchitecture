using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Client.UI.Converters;

public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool booleanValue)
        {
            // parameter가 "False"이면 true/false 뒤집기
            if (parameter is string invert && bool.TryParse(invert, out var paramBool) && paramBool == false)
            {
                booleanValue = !booleanValue;
            }

            return booleanValue ? Visibility.Visible : Visibility.Collapsed;
        }

        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
        {
            bool result = visibility == Visibility.Visible;

            // parameter가 "False"이면 다시 뒤집기
            if (parameter is string invert && bool.TryParse(invert, out var paramBool) && paramBool == false)
            {
                result = !result;
            }

            return result;
        }

        return false;
    }
}
