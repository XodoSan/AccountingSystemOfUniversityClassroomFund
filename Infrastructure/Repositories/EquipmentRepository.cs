using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public void AddEquipmentCategory(EquipmentCategory equipmentCategory)
        {
            _context.Set<EquipmentCategory>().Add(equipmentCategory);
        }

        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber)
        {
            return _context.Set<Equipment>()
                .Where(equipment => equipment.EquipmentRoomNumber == roomNumber)
                .ToList();
        }

        public List<Equipment> GetEquipmentsByCategoryName(string categoryName)
        {
            return _context.Set<Equipment>()
                .Where(equipment => equipment.EquipmentCategoryName == categoryName)
                .ToList();
        }

        public Equipment GetEquipmentByInventoryNumber(int inventoryNumber)
        {
            return _context.Set<Equipment>()
                .Where(equipment => equipment.InventoryNumber == inventoryNumber)
                .Include(equipment => equipment.WhereUsed)
                .First();
        }

        public Usage GetEquipmentUsageByInventoryNumber(int inventoryNumber)
        {
            return _context.Set<Usage>()
                .Where(usage => usage.EquipmentInventoryNumber == inventoryNumber)
                .First();
        }

        public void DeleteEquipment(Equipment currentEquipment)
        {
            _context.Set<Equipment>().Remove(currentEquipment);
        }
    }
}