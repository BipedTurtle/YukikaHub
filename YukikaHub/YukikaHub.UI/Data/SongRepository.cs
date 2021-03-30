using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.DataAccess;
using YukikaHub.Model;

namespace YukikaHub.UI.Data
{
    public class SongRepository : GenericRepository<Song, YukikaHubDbContext>, ISongRepository
    {
        public SongRepository(YukikaHubDbContext context)
            : base(context)
        { }

        public async Task UpdateAndAddSongs(IEnumerable<Song> songs, int albumId)
        {
            var album = await _context.Albums.FindAsync(albumId);
            if (album == null)
                return;

            foreach (var song in songs) {
                var songInDb = await _context.Songs
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(s => s.Title == song.Title);
                if (songInDb != null) {
                    song.Id = songInDb.Id;
                    _context.Entry(song).State = EntityState.Modified;
                }
                else
                    _context.Entry(song).State = EntityState.Added;

                album.Songs.Add(song);
            }

            await _context.SaveChangesAsync();
        }

        class SongEqualityComparer : IEqualityComparer<Song>
        {
            public bool Equals(Song x, Song y)
            {
                return x.Title.Equals(y.Title);
            }

            public int GetHashCode([DisallowNull] Song song)
            {
                return song.Title.GetHashCode();
            }
        }
    }
}
