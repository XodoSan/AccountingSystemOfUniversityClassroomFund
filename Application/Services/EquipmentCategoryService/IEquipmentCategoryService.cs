namespace Application.Services.EquipmentCategoryService
{
    public interface IEquipmentCategoryService
    {
        public void UpdateAllEquipmentCategoryAmounts();
        public void UpdateCurrentEquipmentCategoryAmount(string equipmentCategoryName);
    }
}
