using Application.DTOs;
using Application.Services.WorkerService;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api/[controller]/{subdivisionName}")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        private readonly IUnitOfWork _unitOfWork;

        public WorkerController(IWorkerService workerService, IUnitOfWork unitOfWork)
        {
            _workerService = workerService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add/worker")]
        public void AddWorker([FromRoute] string subdivisionName, [FromBody] WorkerDTO workerDTO)
        {
            _workerService.AddWorkerInSubdivision(subdivisionName, workerDTO);
            _unitOfWork.Commit();
        }
    }
}