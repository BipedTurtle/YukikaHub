using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;
using YukikaHub.UI.Data;

namespace YukikaHub.UI.ViewModels
{
    public class AlbumsViewModel : ViewModelBase, IDetailViewModel
    {
        private IAlbumRepository _albumRepository;
        public ObservableCollection<Album> Albums { get; set; } = new ObservableCollection<Album>();

        public AlbumsViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public event EventHandler AlbumsLoaded;
        public async Task LoadAsync()
        {
            var albums = (await _albumRepository.GetAllNoTrackingAsync()).ToList();

            foreach (var album in albums)
                this.Albums.Add(album);

            this.AlbumsLoaded?.Invoke(this, EventArgs.Empty);
        }
    }
}
