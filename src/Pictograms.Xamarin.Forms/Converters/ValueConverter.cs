using System;
using System.Globalization;

namespace Xamarin.Forms.Pictograms
{
    public class ValueConverter<T> : IValueConverter where T : Pictogram
    {
        public ValueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack(value);
        }

        public static object Convert(object value)
        {
            if (value != null)
            {
                return Pictogram.GetInstance<T>().GetText((int)value);
            }
            return null;
        }

        public static object ConvertBack(object value)
        {
            return null;
        }
    }
}