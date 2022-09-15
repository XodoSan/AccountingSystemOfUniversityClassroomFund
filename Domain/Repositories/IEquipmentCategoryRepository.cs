using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEquipmentCategoryRepository
    {
        public EquipmentCategory GetEquipmentCategoryByName(string categoryName);
        public List<EquipmentCategory> GetAllEquipmentCategories();
    }
}
