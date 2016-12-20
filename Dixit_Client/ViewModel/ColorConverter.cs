using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Dixit_Client.ViewModel
{
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) {
                return Binding.DoNothing;
            }

            int val = (int)value;
            switch (val) {
                case 1000: return "Aquamarine";
                case 1001: return "Purple";
                case 1002: return "Green";
                case 1003: return "Yellow";
                case 1004: return "Blue";
                case 1005: return "Red";
                case 1006: return "Orange";
                case 1007: return "Cyan";
                default: return "Black";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
