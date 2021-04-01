using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YukikaHub.Model;

namespace YukikaHub.UI.UserControls
{
    /// <summary>
    /// Interaction logic for AlbumLookup.xaml
    /// </summary>
    public partial class AlbumLookup : UserControl
    {
        private Album _album;
        public AlbumLookup()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _album = (Album)DataContext;
            this.LoadAlbumImage();
        }

        private void LoadAlbumImage()
        {
            var bitmapImg = new BitmapImage();

            using (var pictureStream = new MemoryStream(_album.Picture))
            {
                bitmapImg.BeginInit();
                bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImg.StreamSource = pictureStream;
                bitmapImg.EndInit();

                Picture.Source = bitmapImg;
            }
        }
    }
}
