using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHistoryRepository
    {
        public void AddChangeWorkerHistoryItem(EquipmentFinanciallyResponsiblePersonChangeHistoryItem workerChangeHistoryItem);
        public void AddMovementHistoryItem(EquipmentMovementHistoryItem moveventChangeHistoryItem);
        public List<EquipmentFinanciallyResponsiblePersonChangeHistoryItem> GetChangeWorkerHistory();
        public List<EquipmentMovementHistoryItem> GetMovementHistory();
    }
}