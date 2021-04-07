using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace YukikaHub.UI.Converters
{
    public class BytesToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var bitmapImg = new BitmapImage();
            var byteStream = (byte[])value;

            using (var pictureStream = new MemoryStream(byteStream))
            {
                bitmapImg.BeginInit();
                bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImg.StreamSource = pictureStream;
                bitmapImg.EndInit();

                return bitmapImg;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
