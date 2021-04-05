using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.DataAccess;
using YukikaHub.Model;

namespace YukikaHub.UI.Data
{
    public class TicketRepository : GenericRepository<Ticket, YukikaHubDbContext>, ITicketRepository
    {
        public TicketRepository(YukikaHubDbContext context)
            : base(context)
        {

        }
    }
}
