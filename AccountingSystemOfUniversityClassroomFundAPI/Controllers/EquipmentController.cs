using Application.DTOs;
using Application.Services.EquipmentService;
using Application.Services.HistoryService;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api/[controller]/{roomNumber}")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IHistoryService _historyService;
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentController(
            IEquipmentService equipmentService,
            IHistoryService historyService,
            IUnitOfWork unitOfWork)
        {
            _equipmentService = equipmentService;
            _historyService = historyService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public void AddEquipment([FromRoute] int roomNumber, [FromBody] EquipmentDTO equipmentDTO)
        {
            _equipmentService.AddEquipmentInRoom(roomNumber, equipmentDTO);
            _unitOfWork.Commit();
        }

        [HttpPost("add/category")]
        public void AddEquipmentCategory([FromBody] EquipmentCategoryDTO equipmentCategoryDTO)
        {
            _equipmentService.AddEquipmentCategory(equipmentCategoryDTO);
            _unitOfWork.Commit();
        }

        [HttpPut("update")]
        public void UpdateEquipment([FromRoute] int roomNumber, [FromBody] EquipmentDTO equipmentDTO)
        {
            _equipmentService.UpdateEquipment(roomNumber, equipmentDTO);
            _unitOfWork.Commit();
        }

        [HttpDelete("delete/{equipmentInventoryNumber}")]
        public void DeleteEquipment([FromRoute] int equipmentInventoryNumber)
        {
            _equipmentService.DeleteEquipmentByInventoryNumber(equipmentInventoryNumber);
            _unitOfWork.Commit();
        }
    }
}