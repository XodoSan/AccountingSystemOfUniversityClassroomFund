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
        private readonly IEquipmentCategoryRepository _equipmentCategoryRepository;
        private readonly IMapper _mapper;

        public EquipmentService(
            IEquipmentRepository equipmentRepository,
            IWorkerRepository workerRepository,
            IEquipmentCategoryRepository equipmentCategoryRepository,
            IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _workerRepository = workerRepository;
            _equipmentCategoryRepository = equipmentCategoryRepository;
            _mapper = mapper;
        }

        public void AddEquipmentInRoom(int roomNumber, EquipmentDTO equipmentDTO)
        {
            Equipment equipment = _mapper.Map<Equipment>(equipmentDTO);
            equipment.EquipmentRoomNumber = roomNumber;

            equipment.WhereUsed = _mapper.Map<Usage>(equipmentDTO.WhereUsed);
            equipment.WhereUsed.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;

            equipment.Category = _mapper.Map<EquipmentCategory>(equipmentDTO.Category);
            equipment.EquipmentCategoryName = equipment.Category.Name;

            Worker currentWorker = _workerRepository.GetWorkerById(equipmentDTO.FinanciallyResponsiblePerson.Id);
            equipment.FinanciallyResponsiblePerson = currentWorker;
            equipment.EquipmentWorkerId = equipment.FinanciallyResponsiblePerson.Id;

            _equipmentRepository.AddEquipment(equipment);
        }

        public void AddEquipmentCategory(EquipmentCategoryDTO equipmentCategoryDTO)
        {
            EquipmentCategory category = _mapper.Map<EquipmentCategory>(equipmentCategoryDTO);
            _equipmentRepository.AddEquipmentCategory(category);
        }

        public void UpdateEquipment(int roomNumber, EquipmentDTO equipmentDTO)
        {
            Equipment currentEquipment = _equipmentRepository
                .GetEquipmentByInventoryNumber(equipmentDTO.InventoryNumber);
            Equipment equipment = _mapper.Map(equipmentDTO, currentEquipment);
            equipment.EquipmentRoomNumber = roomNumber;

            equipment.EquipmentWorkerId = equipmentDTO.FinanciallyResponsiblePerson.Id;

            EquipmentCategory equipmentCategory = _equipmentCategoryRepository
                .GetEquipmentCategoryByName(equipmentDTO.Category.Name);
            List<Equipment> currentCategoryEquipments = _equipmentRepository
                .GetEquipmentsByCategoryName(equipmentDTO.Category.Name);
            equipmentCategory.CurrentCategoryEquipments = currentCategoryEquipments;
            equipmentCategory.CurrentCategoryEquipments.Add(equipment);

            Usage currentEquipmentUsage = _equipmentRepository
                .GetEquipmentUsageByInventoryNumber(currentEquipment.InventoryNumber);
            Usage equipmentUsage = _mapper.Map(equipmentDTO.WhereUsed, currentEquipmentUsage);
            equipmentUsage.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;
        }

        public void DeleteEquipmentByInventoryNumber(int inventoryNumber)
        {
            Equipment currentEquipment = _equipmentRepository.GetEquipmentByInventoryNumber(inventoryNumber);
            _equipmentRepository.DeleteEquipment(currentEquipment);
        }
    }
}