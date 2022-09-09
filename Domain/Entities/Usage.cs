using Domain.Constants;

namespace Domain.Entities
{
    public class Usage
    {
        public int Id { get; set; }
        public string Instruction { get; set; }
        public Purpose Purpose { get; set; }
        public int EquipmentInventoryNumber { get; set; }
    }
}
