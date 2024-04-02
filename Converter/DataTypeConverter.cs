using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX_test_app.Converter
{
    public class DataTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "null";
            }

            switch (value)
            {
                case TypeCode.String:
                    return value;
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Double:
                    return value.ToString();
                case TypeCode.Boolean:
                    return (bool)value ? "True" : "False";
                default:
                    return value.ToString();  // Handle other types as needed
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();  // Not required for this scenario
        }
    }

}
