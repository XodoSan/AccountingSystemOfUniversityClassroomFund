using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEquipmentRepository
    {
        public void AddEquipment(Equipment equipment);
        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber);
        public void AddEquipmentCategory(EquipmentCategory equipmentCategory);
        public List<Equipment> GetEquipmentsByCategoryName(string categoryName);
        public EquipmentCategory GetEquipmentCategoryByName(string categoryName);
    }
}