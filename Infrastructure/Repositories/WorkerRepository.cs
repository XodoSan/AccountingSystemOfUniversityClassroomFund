using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly AppDBContext _context;

        public WorkerRepository(AppDBContext context)
        {
            _context = context;
        }

        public void AddWorker(Worker worker)
        {
            _context.Set<Worker>().Add(worker);
        }

        public Worker GetWorkerById(int workerId)
        {
            return _context.Set<Worker>()
                .Where(worker => worker.Id == workerId)
                .FirstOrDefault();
        }

        public Worker GetWorkerByEquipmentInventoryNumber(int equipmentInventoryNumber)
        {
            return _context.Set<Worker>()
                .Where(worker => worker.EquipmentInventoryNumber == equipmentInventoryNumber)
                .FirstOrDefault();
        }
    }
}
