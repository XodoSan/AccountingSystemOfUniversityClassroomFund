using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly AppDBContext _context;

        public HistoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public void AddChangeWorkerHistoryItem(
            EquipmentFinanciallyResponsiblePersonChangeHistoryItem workerChangeHistoryItem)
        {
            _context.Set<EquipmentFinanciallyResponsiblePersonChangeHistoryItem>().Add(workerChangeHistoryItem);
        }

        public void AddMovementHistoryItem(EquipmentMovementHistoryItem moveventChangeHistoryItem)
        {
            _context.Set<EquipmentMovementHistoryItem>().Add(moveventChangeHistoryItem);
        }

        public List<EquipmentFinanciallyResponsiblePersonChangeHistoryItem> GetChangeWorkerHistory()
        {
            return _context.Set<EquipmentFinanciallyResponsiblePersonChangeHistoryItem>().ToList();
        }

        public List<EquipmentMovementHistoryItem> GetMovementHistory()
        {
            return _context.Set<EquipmentMovementHistoryItem>().ToList();
        }
    }
}