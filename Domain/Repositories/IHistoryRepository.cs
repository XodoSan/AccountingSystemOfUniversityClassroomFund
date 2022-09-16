using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domain.Repositories
{
    public interface IHistoryRepository
    {
        public IEnumerable<EntityEntry> GetEntitiesEntries();
        public void AddChangeWorkerHistoryItem(EquipmentFinanciallyResponsiblePersonChangeHistory workerChangeHistoryItem);
        public void AddChangeMovementHistoryItem(EquipmentMovementHistory moveventChangeHistoryItem);
    }
}