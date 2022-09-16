namespace Domain.Entities
{
    public class EquipmentMovementHistory
    {
        public EquipmentMovementHistory(
            DateTime movementTime, 
            int previousRoomNumber, 
            int roomNumber,
            int equipmentInventoryNumber)
        {
            MovementTime = movementTime;
            PreviousRoomNumber = previousRoomNumber;
            RoomNumber = roomNumber;
            EquipmentInventoryNumber = equipmentInventoryNumber;
        }

        public int Id { get; protected set; }
        public DateTime MovementTime { get; set; }
        public int PreviousRoomNumber { get; set; }
        public int RoomNumber { get; set; }
        public int EquipmentInventoryNumber { get; set; }
    }
}
