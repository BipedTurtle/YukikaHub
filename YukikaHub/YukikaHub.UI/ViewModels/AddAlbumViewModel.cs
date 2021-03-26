using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using YukikaHub.Model;
using YukikaHub.UI.Wrapper;

namespace YukikaHub.UI.ViewModels
{
    public class AddAlbumViewModel : ViewModelBase, IDetailViewModel
    {
        public AddAlbumViewModel()
        {
            this.BrowseImageCommand = new DelegateCommand(this.BrowseImage_Execute);
            this.UploadAlbumCommand = new DelegateCommand(this.UploadAlbum_Execute);

            this.Album = new AlbumWrapper(new Album());
        }

        public event Action<BitmapImage> UploadAlbumImage;

        #region Properties
        public AlbumWrapper Album { get; set; }
        #endregion

        #region Commands
        public ICommand BrowseImageCommand { get; }
        public ICommand AddSongCommand { get; }
        public ICommand RemoveSongCommand { get; }
        public ICommand UploadAlbumCommand { get; }
        #endregion

        #region Command Handlers
        public void BrowseImage_Execute()
        {
            var fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Image Files (*.img;*.jpg)|*img;*jpg;*jpeg";
            if (fileDialog.ShowDialog() == false)
                return;

            var uri = new Uri(fileDialog.FileName);
            var bitmap = new BitmapImage(uri);
            this.UploadAlbumImage?.Invoke(bitmap);
        }

        public void UploadAlbum_Execute()
        {
        }
        #endregion


    }
}