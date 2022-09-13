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

        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber)
        {
            return _context.Set<Equipment>()
                .Where(equipment => equipment.RoomNumber == roomNumber)
                .ToList();
        }

        public void AddEquipmentCategory(EquipmentCategory equipmentCategory)
        {
            _context.Set<EquipmentCategory>().Add(equipmentCategory);
        }

        public List<Equipment> GetEquipmentsByCategoryName(string categoryName)
        {
            return _context.Set<Equipment>()
                .Where(equipment => equipment.EquipmentCategoryName == categoryName)
                .ToList();
        }

        public EquipmentCategory GetEquipmentCategoryByName(string categoryName)
        {
            return _context.Set<EquipmentCategory>()
                .Where(category => category.Name == categoryName)
                .FirstOrDefault();
        }
    }
}
