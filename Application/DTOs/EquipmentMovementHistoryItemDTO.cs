namespace Application.DTOs
{
    public class EquipmentMovementHistoryItemDTO
    {
        public int Id { get; protected set; }
        public DateTime MovementTime { get; set; }
        public int PreviousRoomNumber { get; set; }
        public int CurrentRoomNumber { get; set; }
        public int EquipmentInventoryNumber { get; set; }
    }
}
