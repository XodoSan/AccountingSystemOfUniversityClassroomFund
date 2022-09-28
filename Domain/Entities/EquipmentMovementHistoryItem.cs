namespace Domain.Entities
{
    public class EquipmentMovementHistoryItem
    {
        public EquipmentMovementHistoryItem(
            DateTime movementTime, 
            int previousRoomNumber, 
            int currentRoomNumber,
            int equipmentInventoryNumber)
        {
            MovementTime = movementTime;
            PreviousRoomNumber = previousRoomNumber;
            CurrentRoomNumber = currentRoomNumber;
            EquipmentInventoryNumber = equipmentInventoryNumber;
        }

        public int Id { get; protected set; }
        public DateTime MovementTime { get; set; }
        public int PreviousRoomNumber { get; set; }
        public int CurrentRoomNumber { get; set; }
        public int EquipmentInventoryNumber { get; set; }
    }
}
