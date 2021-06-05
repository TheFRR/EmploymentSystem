using JobSeeker.Infrastructure.Structures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace JobSeeker.Infrastructure.Converters
{
    public class RegistrationDataMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new RegistrationData()
            {
                Name = values[0].ToString(),
                Surname = values[1].ToString(),
                Login = values[2].ToString(),
                PasswordBox = values[3] as PasswordBox
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            RegistrationData data = value as RegistrationData;
            return new object[] { data.Name, data.Surname, data.Login, data.PasswordBox };
        }
    }
}
