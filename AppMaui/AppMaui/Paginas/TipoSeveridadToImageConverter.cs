using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace AppMaui.Converters
{
    public class TipoSeveridadToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "default.png";

            int tipo = (int)value;
            return tipo switch
            {
                1 => "uno.png",
                2 => "dos.png",
                3 => "tres.png",
                4 => "cuatro.png",
                _ => "default.png"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
