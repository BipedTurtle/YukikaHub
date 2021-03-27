using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using YukikaHub.Model;
using YukikaHub.UI.Data;
using YukikaHub.UI.Wrapper;

namespace YukikaHub.UI.ViewModels
{
    public class AddAlbumViewModel : ViewModelBase, IDetailViewModel
    {
        private Song _selectedSong;
        private ISongRepository _songRepository;

        public AddAlbumViewModel(ISongRepository songRepository)
        {
            this.BrowseImageCommand = new DelegateCommand(this.BrowseImage_Execute);
            this.UploadAlbumCommand = new DelegateCommand(this.UploadAlbum_Execute);
            this.AddSongCommand = new DelegateCommand(this.AddSong_Execute);
            this.RemoveSongCommand = new DelegateCommand(this.RemoveSong_Execute, this.RemoveSong_CanExecute);

            _songRepository = songRepository;

            this.Album = new AlbumWrapper(new Album());
            #region a trick to trigger validation
            this.Album.Title = "";
            this.Album.Price = 0;
            #endregion
            this.Album.Songs.Add(new Song {
                Id = 1,
                Title = "Soul Lady",
                Duration = new TimeSpan(0, 3, 24),
                Composer = "Jinbae Park",
                Lyricist = "Oreo",
                Ratings = 5
            });
        }

        public event Action<BitmapImage> UploadAlbumImage;

        #region Properties
        public AlbumWrapper Album { get; set; }
        public Song SelectedSong
        {
            get => _selectedSong;
            set
            {
                _selectedSong = value;
                ((DelegateCommand)this.RemoveSongCommand).RaiseCanExecuteChanged();
            }
        }
        public bool HasSong { get => this.Album.Songs.Count > 0; }
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

        public void AddSong_Execute()
        {
            var newSong = new Song()
            {
                Id = 0,
                Duration = new TimeSpan(0, 0, 0),
                Composer = "Composer Name",
                Lyricist = "Lyricst Name",
                Ratings = 5,
                Title = "Title of the song"
            };

            this.Album.Songs.Add(newSong);
            base.OnPropertyChanged(nameof(HasSong));
        }

        public void RemoveSong_Execute()
        {
            this.Album.Songs.Remove(this.SelectedSong);
            base.OnPropertyChanged(nameof(HasSong));
        }

        public bool RemoveSong_CanExecute()
        {
            return this.SelectedSong != null;
        }
        #endregion


    }
}