using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Client.UI.Converters;

public class IsRunningMultiConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.OfType<bool>().Any(b => b) is bool booleanValue)
        {
            return booleanValue ? Visibility.Visible : Visibility.Collapsed;
        }

        return Visibility.Collapsed;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
