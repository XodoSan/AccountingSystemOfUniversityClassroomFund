using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDBContext _context;

        public EquipmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public void AddEquipment(Equipment equipment)
        {
            _context.Set<Equipment>().Add(equipment);
        }

        public Worker GetWorkerByEquipmentInventoryNumber(int equipmentInventoryNumber)
        {
            return _context.Set<Worker>()
                .Where(worker => worker.EquipmentInventoryNumber == equipmentInventoryNumber)
                .FirstOrDefault();
        }

        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber)
        {
            return _context.Set<Equipment>()
                .Where(equipment => equipment.RoomNumber == roomNumber)
                .ToList();
        }
    }
}
