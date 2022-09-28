namespace Domain.Entities
{
    public class EquipmentFinanciallyResponsiblePersonChangeHistoryItem
    {
        public EquipmentFinanciallyResponsiblePersonChangeHistoryItem(
            DateTime changeTime, 
            int previousFinanciallyResponsiblePersonId, 
            int currentFinanciallyResponsiblePersonId,
            int equipmentInventoryNumber)
        {
            ChangeTime = changeTime;
            PreviousFinanciallyResponsiblePersonId = previousFinanciallyResponsiblePersonId;
            CurrentFinanciallyResponsiblePersonId = currentFinanciallyResponsiblePersonId;
            EquipmentInventoryNumber = equipmentInventoryNumber;
        }

        public int Id { get; protected set; }
        public DateTime ChangeTime { get; set; }
        public int PreviousFinanciallyResponsiblePersonId { get; set; }
        public int CurrentFinanciallyResponsiblePersonId { get; set; }
        public int EquipmentInventoryNumber { get; set; }
    }
}