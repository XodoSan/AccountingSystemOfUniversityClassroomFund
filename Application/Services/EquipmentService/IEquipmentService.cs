using Application.DTOs;

namespace Application.Services.EquipmentService
{
    public interface IEquipmentService
    {
        public void AddEquipmentInRoom(int roomNumber, EquipmentDTO equipmentDTO);
        public void AddEquipmentCategory(EquipmentCategoryDTO equipmentCategoryDTO);
        public void UpdateEquipment(int roomNumber, EquipmentDTO equipmentDTO);
        public void DeleteEquipmentByInventoryNumber(int inventoryNumber);
    }
}
