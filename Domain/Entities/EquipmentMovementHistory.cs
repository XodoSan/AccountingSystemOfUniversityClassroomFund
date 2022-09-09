using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class EquipmentMovementHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime MovementTime { get; set; }
        public int EquipmentInventoryNumber { get; set; }
        public int PreviousRoomNumber { get; set; }
        public int CurrentRoomNumber { get; set; }
    }
}
