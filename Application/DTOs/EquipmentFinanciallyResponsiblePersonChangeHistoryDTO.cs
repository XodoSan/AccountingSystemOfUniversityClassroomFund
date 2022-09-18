﻿namespace Application.DTOs
{
    public class EquipmentFinanciallyResponsiblePersonChangeHistoryDTO
    {
        public int Id { get; protected set; }
        public DateTime ChangeTime { get; set; }
        public int PreviousFinanciallyResponsiblePersonId { get; set; }
        public int CurrentFinanciallyResponsiblePersonId { get; set; }
        public int EquipmentInventoryNumber { get; set; }
    }
}
