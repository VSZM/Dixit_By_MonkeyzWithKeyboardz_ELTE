using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using Dixit_Data;
using System.Windows;
using System.Windows.Media.Imaging;
using Dixit.Injectors;
using Dixit_Data.Interfaces;

namespace Dixit_Client.ViewModel
{
    /// <summary>
    /// Gets the picture's Id and returns the corresponding image
    /// </summary>
    class PictureConverter : IValueConverter
    {
        private ICardAccess ca = DataInjector.Container.GetInstance<ICardAccess>();
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }

            /* //it is Brigi's commit
            if ((int)value == 0) {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                ca.GetCardBack().GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            }*/

            if ((int)value == 0) {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                ca.GetImageById(1).GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            }


                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                ca.GetImageById((int)value).GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
