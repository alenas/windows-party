using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace App.Converters {

    public class StringToVisibilityConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, string language) {
            return (value is string && !string.IsNullOrWhiteSpace((string)value)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
