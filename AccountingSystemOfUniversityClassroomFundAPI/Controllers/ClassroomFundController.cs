using Application.DTOs;
using Application.Services.ClassroomFundService;
using Application.Services.EquipmentCategoryService;
using Application.Services.EquipmentService;
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
        private readonly IEquipmentCategoryService _equipmentCategoryService;

        public ClassroomFundController(
            IClassroomFundService fundService, 
            IUnitOfWork unitOfWork,
            IEquipmentCategoryService equipmentCategoryService)
        {
            _fundService = fundService;
            _unitOfWork = unitOfWork;
            _equipmentCategoryService = equipmentCategoryService;
        }

        [HttpPost("add/room/{universityName}")]
        public void AddRoom([FromRoute] string universityName, [FromBody] RoomDTO roomDTO)
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
        public void UpdateRoom([FromRoute] string universityName, [FromBody] RoomDTO roomDTO)
        {
            _fundService.UpdateRoom(universityName, roomDTO);
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

            _equipmentCategoryService.UpdateAllEquipmentCategoryAmounts();
            _unitOfWork.Commit();
        }
    }
}