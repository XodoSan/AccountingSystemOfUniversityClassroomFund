using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class EquipmentCategory
    {
        [Key]
        public string Name { get; set; }
        public int EquipmentAmount { get; set; }
    }
}
