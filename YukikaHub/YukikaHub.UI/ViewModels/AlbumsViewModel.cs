using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YukikaHub.Model;
using YukikaHub.UI.Data;
using YukikaHub.UI.Events;

namespace YukikaHub.UI.ViewModels
{
    public class AlbumsViewModel : ViewModelBase, IDetailViewModel
    {
        private IAlbumRepository _albumRepository;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<Album> Albums { get; set; } = new ObservableCollection<Album>();

        public AlbumsViewModel(IEventAggregator eventAggregator,
            IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
            _eventAggregator = eventAggregator;

            this.AddAlbumCommand = new DelegateCommand(this.AddAlbum);
        }

        public event EventHandler AlbumsLoaded;
        public async Task LoadAsync()
        {
            var albums = (await _albumRepository.GetAllNoTrackingAsync()).ToList();

            foreach (var album in albums)
                this.Albums.Add(album);

            this.AlbumsLoaded?.Invoke(this, EventArgs.Empty);
        }

        #region Commands
        public ICommand AddAlbumCommand { get; set; }
        #endregion

        #region Command Handlers
        public void AddAlbum()
        {
            _eventAggregator
                .GetEvent<SelectedDetailViewChangedEvent>()
                .Publish(new DetailViewChangedEventArgs(typeof(AddAlbumViewModel).Name));
        }
        #endregion
    }
}
