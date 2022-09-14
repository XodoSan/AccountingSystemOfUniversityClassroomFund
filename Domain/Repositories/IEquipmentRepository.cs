using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEquipmentRepository
    {
        public void AddEquipment(Equipment equipment);
        public void AddEquipmentCategory(EquipmentCategory equipmentCategory);
        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber);
        public List<Equipment> GetEquipmentsByCategoryName(string categoryName);
        public Equipment GetEquipmentByInventoryNumber(int inventoryNumber);
        public EquipmentCategory GetEquipmentCategoryByName(string categoryName);
        public List<EquipmentCategory> GetAllEquipmentCategories();
        public Usage GetEquipmentUsageByInventoryNumber(int inventoryNumber);
        public void DeleteEquipment(Equipment currentEquipment);
    }
}