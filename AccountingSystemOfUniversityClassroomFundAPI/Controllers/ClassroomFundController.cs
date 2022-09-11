using Application.DTOs;
using Application.Services;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("{universityName}")]
        public void AddRoom([FromRoute] string universityName, [FromBody] RoomDTO roomDTO)
        {
            _fundService.AddRoom(universityName, roomDTO);
            _unitOfWork.Commit();
        }

        [HttpPost]
        public void AddUniversityBuilding([FromBody] UniversityBuildingDTO universityBuildingDTO)
        {
            _fundService.AddUniversityBuilding(universityBuildingDTO);
            _unitOfWork.Commit();
        }
    }
}