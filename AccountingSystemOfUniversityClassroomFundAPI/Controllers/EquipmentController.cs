﻿using Application.DTOs;
using Application.Services.EquipmentService;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api/[controller]/{roomNumber}")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentController(IEquipmentService equipmentService, IUnitOfWork unitOfWork)
        {
            _equipmentService = equipmentService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void AddEquipment([FromRoute] int roomNumber, [FromBody] EquipmentDTO equipmentDTO)
        {
            _equipmentService.AddEquipmentInRoom(roomNumber, equipmentDTO);
            _equipmentService.UpdateEquipmentFinanciallyResponsiblePerson(equipmentDTO);
            _unitOfWork.Commit();

            _equipmentService.UpdateCurrentEquipmentCategoryAmount(equipmentDTO);
            _unitOfWork.Commit();
        }

        [HttpPost("add/category")]
        public void AddEquipmentCategory([FromBody] EquipmentCategoryDTO equipmentCategoryDTO)
        {
            _equipmentService.AddEquipmentCategory(equipmentCategoryDTO);
            _unitOfWork.Commit();
        }
    }
}