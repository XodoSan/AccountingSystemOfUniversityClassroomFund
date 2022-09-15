using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class EquipmentCategoryRepository : IEquipmentCategoryRepository
    {
        private readonly AppDBContext _context;

        public EquipmentCategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public EquipmentCategory GetEquipmentCategoryByName(string categoryName)
        {
            return _context.Set<EquipmentCategory>()
                .Where(category => category.Name == categoryName)
                .First();
        }

        public List<EquipmentCategory> GetAllEquipmentCategories()
        {
            return _context.Set<EquipmentCategory>().ToList();
        }
    }
}
