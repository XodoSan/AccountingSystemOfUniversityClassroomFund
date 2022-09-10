using Application.DTOs;
using Application.Services;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api/[controller]/{universityName}")]
    [ApiController]
    public class ClassroomFundController : ControllerBase
    {
        private readonly IClassroomFundService _fundService;
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomFundController(IClassroomFundService fundService, IUnitOfWork unitOfWork)
        {
            _fundService = fundService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void AddRoom([FromRoute] string universityName, [FromBody] RoomDTO roomDTO)
        {
            _fundService.AddRoom(universityName, roomDTO);
            _unitOfWork.Commit();
        }
    }
}