using Domain.Entities;

namespace Domain.Repositories
{
    public interface IWorkerRepository
    {
        public void AddWorker(Worker worker);
        public Worker GetWorkerById(int workerId);
    }
}
