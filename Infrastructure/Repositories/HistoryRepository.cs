using Domain.Entities;
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

        public void AddChangeWorkerHistoryItem(
            EquipmentFinanciallyResponsiblePersonChangeHistory workerChangeHistoryItem)
        {
            _context.Set<EquipmentFinanciallyResponsiblePersonChangeHistory>().Add(workerChangeHistoryItem);
        }

        public void AddChangeMovementHistoryItem(EquipmentMovementHistory moveventChangeHistoryItem)
        {
            _context.Set<EquipmentMovementHistory>().Add(moveventChangeHistoryItem);
        }
    }
}
