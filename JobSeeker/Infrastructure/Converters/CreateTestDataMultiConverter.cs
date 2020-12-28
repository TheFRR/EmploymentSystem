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
    public class CreateTestDataMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new CreateTestData()
            {
                QuestionText = values[0].ToString(),
                VariantsItems = values[1] as ItemsControl
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            CreateTestData data = value as CreateTestData;
            return new object[] { data.QuestionText, data.VariantsItems };
        }
    }
}
