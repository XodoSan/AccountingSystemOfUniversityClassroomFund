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
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public EquipmentService(
            IEquipmentRepository equipmentRepository,
            IWorkerRepository workerRepository,
            IHistoryRepository historyRepository,
            IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _workerRepository = workerRepository;
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public void AddEquipmentInRoom(int roomNumber, EquipmentDTO equipmentDTO)
        {
            Equipment equipment = _mapper.Map<Equipment>(equipmentDTO);

            AddWorkerChangeHistory(equipmentDTO, equipment);
            AddRoomChangeHistory(roomNumber, equipment, equipmentDTO);
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
            Equipment previousEquipment = _equipmentRepository
                .GetEquipmentByInventoryNumber(equipmentDTO.InventoryNumber);

            if (equipmentDTO.FinanciallyResponsiblePerson.Id != previousEquipment.EquipmentWorkerId)
            {
                AddWorkerChangeHistory(equipmentDTO, previousEquipment);
            }
                
            if (roomNumber != previousEquipment.EquipmentRoomNumber)
            {
                AddRoomChangeHistory(roomNumber, previousEquipment, equipmentDTO);
            }
                
            Equipment equipment = _mapper.Map(equipmentDTO, previousEquipment);
            equipment.EquipmentRoomNumber = roomNumber;

            equipment.EquipmentWorkerId = equipmentDTO.FinanciallyResponsiblePerson.Id;
            equipment.EquipmentCategoryName = equipmentDTO.Category.Name;
            
            Usage currentEquipmentUsage = _equipmentRepository
                .GetEquipmentUsageByInventoryNumber(previousEquipment.InventoryNumber);
            Usage equipmentUsage = _mapper.Map(equipmentDTO.WhereUsed, currentEquipmentUsage);
            equipmentUsage.EquipmentInventoryNumber = equipmentDTO.InventoryNumber;
        }

        public void DeleteEquipmentByInventoryNumber(int inventoryNumber)
        {
            Equipment currentEquipment = _equipmentRepository.GetEquipmentByInventoryNumber(inventoryNumber);
            _equipmentRepository.DeleteEquipment(currentEquipment);
        }

        private void AddWorkerChangeHistory(EquipmentDTO equipmentDTO, Equipment previousEquipment)
        {
            EquipmentFinanciallyResponsiblePersonChangeHistory workerChangeHistoryItem = new(
                     DateTime.Now,
                     previousEquipment.EquipmentWorkerId,
                     equipmentDTO.FinanciallyResponsiblePerson.Id,
                     equipmentDTO.InventoryNumber);

            _historyRepository.AddChangeWorkerHistoryItem(workerChangeHistoryItem);
        }

        private void AddRoomChangeHistory(int roomNumber, Equipment previousEquipment, EquipmentDTO equipmentDTO)
        {
            EquipmentMovementHistory movementHistoryItem = new(
                    DateTime.Now,
                    equipmentDTO.InventoryNumber,
                    previousEquipment.EquipmentRoomNumber,
                    roomNumber);

            _historyRepository.AddChangeMovementHistoryItem(movementHistoryItem);
        }
    }
}