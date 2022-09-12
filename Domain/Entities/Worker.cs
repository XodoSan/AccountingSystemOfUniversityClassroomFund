namespace Domain.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string SubdivisionName { get; set; }
        public int? EquipmentInventoryNumber { get; set; }
    }
}
