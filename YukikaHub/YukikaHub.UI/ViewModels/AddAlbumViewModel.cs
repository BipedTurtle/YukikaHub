using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using YukikaHub.Model;
using YukikaHub.UI.Data;
using YukikaHub.UI.Wrapper;
using YukikaHub.UI.Extensions;
using System.Collections.Generic;
using System.IO;
using MaterialDesignThemes.Wpf;
using YukikaHub.UI.UserControls.Dialogs;
using System.Threading.Tasks;

namespace YukikaHub.UI.ViewModels
{
    public class AddAlbumViewModel : BrowseImageViewModel, IDetailViewModel
    {
        private Song _selectedSong;
        private ISongRepository _songRepository;
        private IAlbumRepository _albumRepository;

        public AddAlbumViewModel(ISongRepository songRepository,
            IAlbumRepository albumRepository)
        {
            this.UploadAlbumCommand = new DelegateCommand(this.UploadAlbum_Execute, this.UploadAlbum_CanExecute);
            this.AddSongCommand = new DelegateCommand(this.AddSong_Execute);
            this.RemoveSongCommand = new DelegateCommand(this.RemoveSong_Execute, this.RemoveSong_CanExecute);

            _songRepository = songRepository;
            _albumRepository = albumRepository;

            this.Album = new AlbumWrapper(new Album());
            // this is what notifies the upload button to toggle on whenever a property of album changes
            this.Album.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(Album.HasErrors))
                    ((DelegateCommand)UploadAlbumCommand).RaiseCanExecuteChanged();
            };
            base._imageWrapper = this.Album;

            #region a trick to trigger validation
            this.Album.Title = "";
            this.Album.Price = 0;
            #endregion
            this.Songs.Add(new Song {
                Title = "Soul Lady",
                Duration = new TimeSpan(0, 3, 24),
                Composer = "Jinbae Park",
                Lyricist = "Oreo",
                Ratings = 5
            });
        }

        #region Events
        public event Action<string> AlbumUploaded;
        #endregion

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
        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song>();
        public bool HasSong { get => this.Songs.Count > 0; }
        public bool SongsAreDistinct
        {
            get => !this.Songs.Select(s => s.Title).HasDuplicate();
        }
        #endregion

        #region Commands
        public ICommand AddSongCommand { get; }
        public ICommand RemoveSongCommand { get; }
        public ICommand UploadAlbumCommand { get; }
        #endregion

        #region Command Handlers
        public async void UploadAlbum_Execute()
        {
            if (!this.SongsAreDistinct)
                return;

            (bool albumHasBeenAdded, int albumId) result = await _albumRepository.TryAddAsync(this.Album.Model);
            if (result.albumHasBeenAdded) {
                await _songRepository.UpdateAndAddSongs(this.Songs, result.albumId);
                UpdateUI();
            }


            void UpdateUI()
            {
                this.AlbumUploaded?.Invoke(this.Album.Title);

                this.Album = new AlbumWrapper(new Album());
                this.Songs.Clear();
                OnPropertyChanged(nameof(Album));
            }
        }

        public bool UploadAlbum_CanExecute()
        {
            return
                this.HasSong &&
                !this.Album.HasErrors;
        }

        public void AddSong_Execute()
        {
            var newSong = new Song()
            {
                Duration = new TimeSpan(0, 0, 0),
                Composer = "Composer Name",
                Lyricist = "Lyricst Name",
                Ratings = 5,
                Title = "Title of the song"
            };

            this.Songs.Add(newSong);
            base.OnPropertyChanged(nameof(HasSong));
            ((DelegateCommand)UploadAlbumCommand).RaiseCanExecuteChanged();
        }

        public void RemoveSong_Execute()
        {
            this.Songs.Remove(this.SelectedSong);
            base.OnPropertyChanged(nameof(HasSong));
            ((DelegateCommand)UploadAlbumCommand).RaiseCanExecuteChanged();
        }

        public bool RemoveSong_CanExecute()
        {
            return this.SelectedSong != null;
        }

        public Task LoadAsync(object parameter)
        {
            return Task.CompletedTask;
        }
        #endregion
    }
}