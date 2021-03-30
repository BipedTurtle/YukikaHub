using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;

namespace YukikaHub.UI.Data
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {

        public Task<(bool, int)> TryAddAsync(Album album);
    }
}
