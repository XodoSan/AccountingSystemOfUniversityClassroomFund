using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Repositories;

namespace Application.Services.EquipmentCategoryService
{
    public class EquipmentCategoryService : IEquipmentCategoryService
    {
        private readonly IEquipmentCategoryRepository _equipmentCategoryRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentCategoryService(
            IEquipmentCategoryRepository equipmentCategoryRepository, 
            IEquipmentRepository equipmentRepository)
        {
            _equipmentCategoryRepository = equipmentCategoryRepository;
            _equipmentRepository = equipmentRepository;
        }

        public void UpdateAllEquipmentCategoryAmounts()
        {
            List<EquipmentCategory> equipmentCategories = _equipmentCategoryRepository.GetAllEquipmentCategories();
            foreach (EquipmentCategory equipentCategory in equipmentCategories)
            {
                UpdateCurrentEquipmentCategoryAmount(equipentCategory.Name);
            }
        }

        public void UpdateCurrentEquipmentCategoryAmount(string equipmentCategoryName)
        {
            EquipmentCategory currentCategory = _equipmentCategoryRepository
                .GetEquipmentCategoryByName(equipmentCategoryName);
            currentCategory.EquipmentAmount = _equipmentRepository
                .GetEquipmentsByCategoryName(currentCategory.Name)
                .Count;
        }
    }
}
