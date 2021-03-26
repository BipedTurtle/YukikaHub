using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.DataAccess;
using YukikaHub.Model;

namespace YukikaHub.UI.Data
{
    public class SongRepository : GenericRepository<Song, YukikaHubDbContext>
    {
        public SongRepository(YukikaHubDbContext context)
            : base(context)
        { }
    }
}
