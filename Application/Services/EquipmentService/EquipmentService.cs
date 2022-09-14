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

            equipment.WhereUsed = _mapper.Map<Usage>(equipmentDTO.WhereUsed);
            equipment.WhereUsed.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;

            equipment.FinanciallyResponsiblePerson = _mapper.Map<Worker>(equipmentDTO.FinanciallyResponsiblePerson);
            equipment.FinanciallyResponsiblePerson.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;

            equipment.Category = _mapper.Map<EquipmentCategory>(equipmentDTO.Category);
            equipment.EquipmentCategoryName = equipment.Category.Name;

            Worker currentWorker = _workerRepository.GetWorkerById(equipmentDTO.FinanciallyResponsiblePerson.Id);
            equipment.FinanciallyResponsiblePerson = currentWorker;
            equipment.FinanciallyResponsiblePerson.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;

            _equipmentRepository.AddEquipment(equipment);
        }

        public void UpdateEquipmentFinanciallyResponsiblePerson(EquipmentDTO equipmentDTO)
        {
            Worker currentWorker = _workerRepository
                .GetWorkerById(equipmentDTO.FinanciallyResponsiblePerson.Id);
            currentWorker.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;
        }

        public void UpdateCurrentEquipmentCategoryAmount(string equipmentCategoryName)
        {
            EquipmentCategory currentCategory = _equipmentRepository
                .GetEquipmentCategoryByName(equipmentCategoryName);
            currentCategory.EquipmentAmount = _equipmentRepository
                .GetEquipmentsByCategoryName(currentCategory.Name)
                .Count;
        }

        public void AddEquipmentCategory(EquipmentCategoryDTO equipmentCategoryDTO)
        {
            EquipmentCategory category = _mapper.Map<EquipmentCategory>(equipmentCategoryDTO);
            _equipmentRepository.AddEquipmentCategory(category);
        }

        public void UpdateEquipment(int roomNumber, EquipmentDTO equipmentDTO)
        {
            Equipment currentEquipment = _equipmentRepository.GetEquipmentByInventoryNumber(equipmentDTO.InventoryNumber);
            Equipment equipment = _mapper.Map(equipmentDTO, currentEquipment);
            equipment.RoomNumber = roomNumber;

            Worker newWorker = _workerRepository.GetWorkerById(equipmentDTO.FinanciallyResponsiblePerson.Id);
            newWorker.EquipmentInventoryNumber = equipment.InventoryNumber;

            EquipmentCategory equipmentCategory = _equipmentRepository.GetEquipmentCategoryByName(equipmentDTO.Category.Name);
            List<Equipment> currentCategoryEquipments = _equipmentRepository.GetEquipmentsByCategoryName(equipmentDTO.Category.Name);
            equipmentCategory.CurrentCategoryEquipments = currentCategoryEquipments;
            equipmentCategory.CurrentCategoryEquipments.Add(equipment);

            Usage currentEquipmentUsage = _equipmentRepository.GetEquipmentUsageByInventoryNumber(currentEquipment.InventoryNumber);
            Usage equipmentUsage = _mapper.Map(equipmentDTO.WhereUsed, currentEquipmentUsage);
            equipmentUsage.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;

            equipment.Category = equipmentCategory;
            equipment.FinanciallyResponsiblePerson = newWorker;
            equipment.WhereUsed = equipmentUsage;
        }

        public void UpdateAllEquipmentCategoryAmounts()
        {
            List<EquipmentCategory> equipmentCategories = _equipmentRepository.GetAllEquipmentCategories();
            foreach (EquipmentCategory equipentCategory in equipmentCategories)
            {
                UpdateCurrentEquipmentCategoryAmount(equipentCategory.Name);
            }
        }

        public void DeleteEquipmentByInventoryNumber(int inventoryNumber)
        {
            Equipment currentEquipment = _equipmentRepository.GetEquipmentByInventoryNumber(inventoryNumber);
            _equipmentRepository.DeleteEquipment(currentEquipment);
        }
    }
}