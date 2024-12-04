using System;
using System.Globalization;

namespace AppListaTareas.MVVM.Converters
{
	public class SelectedItemConverter:IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedItem = value as string;
            var currentItem = parameter as string;

            return selectedItem == currentItem ? Colors.LightBlue : Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}

