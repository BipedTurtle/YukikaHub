using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.DataAccess;
using YukikaHub.Model;
using YukikaHub.UI.UserControls.Dialogs;

namespace YukikaHub.UI.Data
{
    public class AlbumRepository : GenericRepository<Album, YukikaHubDbContext>, IAlbumRepository
    {
        public AlbumRepository(YukikaHubDbContext context) 
            : base(context) { }

        public async Task<(bool, int)> TryAddAsync(Album album)
        {
            var albumInDb =
                await _context.Albums
                        .AsNoTracking()
                        .SingleOrDefaultAsync(a => a.Title.ToUpper() == album.Title.ToUpper());
            if (albumInDb != null) {
                var dialog = new OkCancelDialog($"Album {albumInDb.Title} already exists. Give it a different title");
                await DialogHost.Show(dialog);
                return (false, 0);
            }

            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return (true, album.Id);
        }
    }
}
