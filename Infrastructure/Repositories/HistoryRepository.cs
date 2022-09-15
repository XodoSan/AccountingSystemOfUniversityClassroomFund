using Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly AppDBContext _context;

        public HistoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<EntityEntry> GetEntitiesEntries()
        {
            return _context.ChangeTracker.Entries();
        }
    }
}
