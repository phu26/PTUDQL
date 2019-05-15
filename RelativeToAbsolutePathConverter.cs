using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace ImPort
{
   
        class RelativeToAbsolutePathConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
            string imagePath = (string)value;
            string absolutePath = "";
            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                // Remove the last /
                var baseFolder = currentFolder.Substring(0, currentFolder.Length - 1);

                var filename = value as string;
                return $"{baseFolder}\\pic\\{filename}";
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
}
