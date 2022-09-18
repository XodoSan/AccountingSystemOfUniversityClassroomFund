using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHistoryRepository
    {
        public void AddChangeWorkerHistoryItem(EquipmentFinanciallyResponsiblePersonChangeHistory workerChangeHistoryItem);
        public void AddMovementHistoryItem(EquipmentMovementHistory moveventChangeHistoryItem);
        public List<EquipmentFinanciallyResponsiblePersonChangeHistory> GetChangeWorkerHistory();
        public List<EquipmentMovementHistory> GetMovementHistory();
    }
}