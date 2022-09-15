using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domain.Repositories
{
    public interface IHistoryRepository
    {
        public IEnumerable<EntityEntry> GetEntitiesEntries();
    }
}
