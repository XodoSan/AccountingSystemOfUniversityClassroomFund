using Application.DTOs;

namespace Application.Services.WorkerService
{
    public interface IWorkerService
    {
        public void AddWorkerInSubdivision(string subdivisionName, WorkerDTO workerDTO);
    }
}
