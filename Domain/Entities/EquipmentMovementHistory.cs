namespace Domain.Entities
{
    public class EquipmentMovementHistory
    {
        public int Id { get; set; }
        public DateTime MovementTime { get; set; }
        public int EquipmentInventoryNumber { get; set; }
        public int PreviousRoomNumber { get; set; }
        public int CurrentRoomNumber { get; set; }
    }
}
