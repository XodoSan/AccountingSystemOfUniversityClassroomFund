using Application.DTOs;
using Application.Services.ClassroomFundService;
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

        public ClassroomFundController(
            IClassroomFundService fundService,
            IUnitOfWork unitOfWork)
        {
            _fundService = fundService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add/room/{universityName}")]
        public void AddRoom([FromRoute] string universityName, [FromForm] RoomDTO roomDTO)
        {            
            _fundService.AddRoomInUniversity(universityName, roomDTO);
            _unitOfWork.Commit();
        }

        [HttpPost("add/university_building")]
        public void AddUniversityBuilding([FromBody] UniversityBuildingDTO universityBuildingDTO)
        {
            _fundService.AddUniversityBuilding(universityBuildingDTO);
            _unitOfWork.Commit();
        }

        [HttpPost("add/subdivision/{universityName}")]
        public void AddSubdivision([FromRoute] string universityName, [FromBody] SubdivisionDTO subdivisionDTO)
        {
            _fundService.AddSubdivisionInUniversity(universityName, subdivisionDTO);
            _unitOfWork.Commit();
        }

        [HttpPut("update/room/{universityName}")]
        public void UpdateRoom([FromForm] RoomDTO roomDTO)
        {
            _fundService.UpdateRoom(roomDTO);
            _unitOfWork.Commit();
        }

        [HttpPut("update/university_building")]
        public void UpdateUniversityBuilding([FromBody] UniversityBuildingDTO universityBuildingDTO)
        {
            _fundService.UpdateUniversityBuilding(universityBuildingDTO);
            _unitOfWork.Commit();
        }

        [HttpDelete("delete/room/{roomNumber}")]
        public void DeleteRoom([FromRoute] int roomNumber)
        {
            _fundService.DeleteRoomByNumber(roomNumber);
            _unitOfWork.Commit();
        }

        [HttpDelete("delete/university_building/{universityName}")]
        public void DeleteUniversityBuilding([FromRoute] string universityName)
        {
            _fundService.DeleteUniversityBuildingByName(universityName);
            _unitOfWork.Commit();
        }
    }
}