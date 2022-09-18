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
            EquipmentFinanciallyResponsiblePersonChangeHistory workerChangeHistoryItem)
        {
            _context.Set<EquipmentFinanciallyResponsiblePersonChangeHistory>().Add(workerChangeHistoryItem);
        }

        public void AddMovementHistoryItem(EquipmentMovementHistory moveventChangeHistoryItem)
        {
            _context.Set<EquipmentMovementHistory>().Add(moveventChangeHistoryItem);
        }

        public List<EquipmentFinanciallyResponsiblePersonChangeHistory> GetChangeWorkerHistory()
        {
            return _context.Set<EquipmentFinanciallyResponsiblePersonChangeHistory>().ToList();
        }

        public List<EquipmentMovementHistory> GetMovementHistory()
        {
            return _context.Set<EquipmentMovementHistory>().ToList();
        }
    }
}