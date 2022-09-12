using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.WorkerService
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerService(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public void AddWorkerInSubdivision(string subdivisionName, WorkerDTO workerDTO)
        {
            Worker worker = _mapper.Map<Worker>(workerDTO);
            worker.SubdivisionName = subdivisionName;
            
            _workerRepository.AddWorker(worker);
        }
    }
}
