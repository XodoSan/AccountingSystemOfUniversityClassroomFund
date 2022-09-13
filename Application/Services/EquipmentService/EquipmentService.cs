using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.EquipmentService
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, 
            IMapper mapper, 
            IWorkerRepository workerRepository)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
            _workerRepository = workerRepository;
        }

        public void AddEquipmentInRoom(int roomNumber, EquipmentDTO equipmentDTO)
        {
            Equipment equipment = _mapper.Map<Equipment>(equipmentDTO);
            equipment.RoomNumber = roomNumber;

            Worker currentWorker = _workerRepository.GetWorkerById(equipmentDTO.FinanciallyResponsiblePerson.Id);
            equipment.FinanciallyResponsiblePerson = currentWorker;

            _equipmentRepository.AddEquipment(equipment);
        }

        public void UpdateEquipmentFinanciallyResponsiblePerson(EquipmentDTO equipmentDTO)
        {
            Worker currentWorker = _workerRepository.GetWorkerById(equipmentDTO.FinanciallyResponsiblePerson.Id);
            currentWorker.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;
        }

        public void UpdateCurrentEquipmentCategoryAmount(EquipmentDTO equipmentDTO)
        {
            EquipmentCategory currentCategory = _equipmentRepository.GetEquipmentCategoryByName(equipmentDTO.Category.Name);
            currentCategory.EquipmentAmount = _equipmentRepository
                .GetEquipmentsByCategoryName(currentCategory.Name)
                .Count;
        }

        public void AddEquipmentCategory(EquipmentCategoryDTO equipmentCategoryDTO)
        {
            EquipmentCategory category = _mapper.Map<EquipmentCategory>(equipmentCategoryDTO);

            _equipmentRepository.AddEquipmentCategory(category);
        }
    }
}
