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

            Worker worker = _workerRepository.GetWorkerByEquipmentInventoryNumber(equipmentDTO.InventoryNumber);
            worker.EquipmentInventoryNumber = equipment.InventoryNumber;

            EquipmentCategory equipmentCategory = _equipmentRepository.GetEquipmentCategoryByName(equipmentDTO.Category.Name);
            List<Equipment> currentCategoryEquipments = _equipmentRepository.GetEquipmentsByCategoryName(equipmentDTO.Category.Name);
            equipmentCategory.CurrentCategoryEquipments = currentCategoryEquipments;
            equipmentCategory.CurrentCategoryEquipments.Add(equipment);

            equipment.Category = equipmentCategory;
        }

        public void UpdateAllEquipmentCategoryAmounts()
        {
            List<EquipmentCategory> equipmentCategories = _equipmentRepository.GetAllEquipmentCategories();
            foreach (EquipmentCategory equipentCategory in equipmentCategories)
            {
                UpdateCurrentEquipmentCategoryAmount(equipentCategory.Name);
            }
        }
    }
}