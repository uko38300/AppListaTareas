using System;
using System.Globalization;

namespace AppListaTareas.MVVM.Converters

{
	public class BoolToYesNoConverter:IValueConverter
	{
		
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? "Si" : "No";
            }
            return "No";
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
			if(value is string stringValue)
			{
				return stringValue.Equals("Si", StringComparison.OrdinalIgnoreCase);
			}
			return false;
            throw new NotImplementedException();
        }
    }
}

