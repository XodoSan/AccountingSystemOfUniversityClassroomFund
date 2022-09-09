namespace Domain.Entities
{
    public class Equipment
    {
        public int InventoryNumber { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public Worker FinanciallyResponsiblePerson { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public DateTimeOffset CommissioningDate { get; set; }
        public float Price { get; set; }
        public EquipmentCategory Category { get; set; }
        public Usage WhereUsed { get; set; }
        public int RoomNumber { get; set; }
    }
}
