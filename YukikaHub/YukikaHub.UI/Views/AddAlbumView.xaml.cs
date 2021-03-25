using System;
using System.Collections.Generic;
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
using YukikaHub.UI.ViewModels;

namespace YukikaHub.UI.Views
{
    /// <summary>
    /// Interaction logic for AddAlbumView.xaml
    /// </summary>
    public partial class AddAlbumView : UserControl
    {
        private AddAlbumViewModel _addAlbumViewModel;

        public AddAlbumView()
        {
            InitializeComponent();
        }

        private void AddAlbumView_Loaded(object sender, RoutedEventArgs e)
        {
            _addAlbumViewModel = (AddAlbumViewModel)this.DataContext;
            _addAlbumViewModel.UploadAlbumImage += OnImageChosen_UploadImage;
        }

        private void OnImageChosen_UploadImage(BitmapImage img)
        {
            AlbumImage.Source = img;
            AlbumImage.Visibility = Visibility.Visible;
        }
    }
}
