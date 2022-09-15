using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Services.HistoryService
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public void CheckEquipmentUpdateFields()
        {
            IEnumerable<EntityEntry> entries = _historyRepository.GetEntitiesEntries();
            foreach (EntityEntry entry in entries)
            {
                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Modified &&
                    typeof(Worker).FullName == (entry.Entity.ToString()))
                {
                    Worker worker = new Worker();
                }
            }
        }
    }
}