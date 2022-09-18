namespace Application.DTOs
{
    public class EquipmentMovementHistoryDTO
    {
        public int Id { get; protected set; }
        public DateTime MovementTime { get; set; }
        public int PreviousRoomNumber { get; set; }
        public int RoomNumber { get; set; }
        public int EquipmentInventoryNumber { get; set; }
    }
}
