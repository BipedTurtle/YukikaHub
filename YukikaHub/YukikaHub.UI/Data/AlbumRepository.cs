using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.DataAccess;
using YukikaHub.Model;

namespace YukikaHub.UI.Data
{
    public class AlbumRepository : GenericRepository<Album, YukikaHubDbContext>
    {
        public AlbumRepository(YukikaHubDbContext context) 
            : base(context) { }
    }
}
