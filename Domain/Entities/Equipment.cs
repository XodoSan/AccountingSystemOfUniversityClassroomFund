namespace Domain.Entities
{
    public class Equipment
    {
        public int InventoryNumber { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public Worker FinanciallyResponsiblePerson { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CommissioningDate { get; set; }
        public float Price { get; set; }
        public EquipmentCategory Category { get; set; }
        public Usage WhereUsed { get; set; }
        public string EquipmentCategoryName { get; set; }
        public int EquipmentWorkerId { get; set; }
        public int EquipmentRoomNumber { get; set; }
    }
}