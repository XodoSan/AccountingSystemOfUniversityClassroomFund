using Application.DTOs;
using Application.Services;
using Application.Services.EquipmentService;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("{roomNumber}/add")]
        public void AddEquipment([FromRoute] int roomNumber, [FromBody] EquipmentDTO equipmentDTO)
        {
            _equipmentService.AddEquipmentInRoom(roomNumber, equipmentDTO);
            _unitOfWork.Commit();
        }

        [HttpPost("{roomNumber}/add/category")]
        public void AddEquipmentCategory([FromBody] EquipmentCategoryDTO equipmentCategoryDTO)
        {
            _equipmentService.AddEquipmentCategory(equipmentCategoryDTO);
            _unitOfWork.Commit();
        }

        [HttpPut("{roomNumber}/update")]
        public void UpdateEquipment([FromRoute] int roomNumber, [FromBody] EquipmentDTO equipmentDTO)
        {
            _equipmentService.UpdateEquipment(roomNumber, equipmentDTO);
            _unitOfWork.Commit();
        }

        [HttpDelete("{roomNumber}/delete/{equipmentInventoryNumber}")]
        public void DeleteEquipment([FromRoute] int equipmentInventoryNumber)
        {
            _equipmentService.DeleteEquipmentByInventoryNumber(equipmentInventoryNumber);
            _unitOfWork.Commit();
        }

        [HttpGet("get/movement_history")]
        public List<EquipmentMovementHistoryItemDTO> GetWholeMovementHistory()
        {
            return _historyService.GetMovementHistory();
        }

        [HttpGet("get/worker_change_history")]
        public List<EquipmentFinanciallyResponsiblePersonChangeHistoryItemDTO> GetWholeChangeWorkerHistory()
        {
            return _historyService.GetChangeWorkerHistory();
        }
    }
}