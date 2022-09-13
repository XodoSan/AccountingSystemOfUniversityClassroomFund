﻿using Domain.Entities;
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
                .Where(equipment => equipment.RoomNumber == roomNumber)
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
                .Include(equipment => equipment.FinanciallyResponsiblePerson)
                .Include(equipment => equipment.WhereUsed)
                .Include(equipment => equipment.Category)
                .FirstOrDefault();
        }

        public EquipmentCategory GetEquipmentCategoryByName(string categoryName)
        {
            return _context.Set<EquipmentCategory>()
                .Where(category => category.Name == categoryName)
                .FirstOrDefault();
        }

        public List<EquipmentCategory> GetAllEquipmentCategories()
        {
            return _context.Set<EquipmentCategory>().ToList();
        }
    }
}
