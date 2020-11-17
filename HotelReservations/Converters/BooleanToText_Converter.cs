using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace HotelReservations.Converters
{
    public class BooleanToText_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(bool))
            {
                if ((bool)value)
                {
                    return "Accepted";
                }
            }
            return "Decline";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }//[Class]
}//[Namespace]