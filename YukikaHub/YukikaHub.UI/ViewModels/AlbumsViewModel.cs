using System;
using System.Collections.Generic;
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
        private List<Album> _albums = new List<Album>();

        public AlbumsViewModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task LoadAsync()
        {
            var albums = (await _albumRepository.GetAllAsync()).ToList();
            
            
        }
    }
}
