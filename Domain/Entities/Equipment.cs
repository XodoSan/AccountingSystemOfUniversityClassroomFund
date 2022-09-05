namespace Domain.Entities
{
    public class Equipment
    {
        public string Name { get; set; }
        public int InventoryNumber { get; set; }
        public int SerialNumber { get; set; }
        public string FinanciallyResponsiblePerson { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CommissioningDate { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public string WhereUsed { get; set; }
    }
}
