using MaterialDesignThemes.Wpf;
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
            _addAlbumViewModel.AlbumUploaded += OnAlbumUploaded_ShowSanckbar;
            _addAlbumViewModel.AlbumUploaded += OnAlbumUploaded_ClearImage;

            var messageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(2500));
            Snackbar.MessageQueue = messageQueue;
        }

        private void OnAlbumUploaded_ShowSanckbar(string albumName)
        {
            Snackbar.MessageQueue.Enqueue($"Album \"{albumName}\" has been successfully uploaded!");
        }

        private void OnAlbumUploaded_ClearImage(string albumName)
        {
            AlbumImage.Source = null;
        }
    }
}
