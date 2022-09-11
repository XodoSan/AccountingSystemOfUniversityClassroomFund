namespace Application.DTOs
{
    public class EquipmentDTO
    {
        public int InventoryNumber { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public WorkerDTO FinanciallyResponsiblePerson { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CommissioningDate { get; set; }
        public float Price { get; set; }
        public EquipmentCategoryDTO Category { get; set; }
        public UsageDTO WhereUsed { get; set; }
    }
}
