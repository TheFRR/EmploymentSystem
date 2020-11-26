﻿using JobSeeker.Infrastructure.Structures;
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
    public class AuthorizationDataMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new AuthorizationData()
            {
                Login = values[0].ToString(),
                PasswordBox = values[1] as PasswordBox
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            AuthorizationData data = value as AuthorizationData;
            return new object[] { data.Login, data.PasswordBox };
        }
    }
}
