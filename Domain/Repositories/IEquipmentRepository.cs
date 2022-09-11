using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEquipmentRepository
    {
        public void AddEquipment(Equipment equipment);
        public Worker GetWorkerByEquipmentInventoryNumber(int equipmentInventoryNumber);
        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber);
    }
}