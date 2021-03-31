using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;

namespace YukikaHub.UI.ViewModels
{
    public class AlbumLookupViewModel : ViewModelBase
    {
        private Album _album;
        public AlbumLookupViewModel(Album album)
        {
            _album = album;
        }

        public Album Album
        {
            get => _album;
            set
            {
                _album = value;
                base.OnPropertyChanged();
            }
        }
    }
}
