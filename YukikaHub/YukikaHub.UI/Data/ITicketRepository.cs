using YukikaHub.DataAccess;
using YukikaHub.Model;

namespace YukikaHub.UI.Data
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        public YukikaHubDbContext Context { get; }
    }
}