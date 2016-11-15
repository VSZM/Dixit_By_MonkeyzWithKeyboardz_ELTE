using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using Dixit_Data;

namespace Dixit_Client.ViewModel
{
    /// <summary>
    /// Gets the picture's Id and returns the corresponding image
    /// </summary>
    class PictureConverter : IValueConverter
    {
        static CardAccess ca = new CardAccess();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }
            
            return ca.GetImageById((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
