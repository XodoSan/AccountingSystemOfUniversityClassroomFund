using Application.DTOs;

namespace Application.Services.EquipmentService
{
    public interface IEquipmentService
    {
        public void AddEquipmentInRoom(int roomNumber, EquipmentDTO equipmentDTO);
        public void AddEquipmentCategory(EquipmentCategoryDTO equipmentCategoryDTO);
        public void UpdateCurrentEquipmentCategoryAmount(string equipmentCategoryName);
        public void UpdateEquipment(int roomNumber, EquipmentDTO equipmentDTO);
        public void UpdateAllEquipmentCategoryAmounts();
        public void DeleteEquipmentByInventoryNumber(int inventoryNumber);
    }
}
