using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.EquipmentService
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public void AddEquipmentInRoom(int roomNumber, EquipmentDTO equipmentDTO)
        {
            Equipment equipment = _mapper.Map<Equipment>(equipmentDTO);
            equipment.RoomNumber = roomNumber;

            Worker currentWorker = _equipmentRepository.GetWorkerByEquipmentInventoryNumber(equipment.InventoryNumber);
            equipment.FinanciallyResponsiblePerson = _mapper.Map<Worker>(currentWorker);
            _equipmentRepository.AddEquipment(equipment);
        }
    }
}
