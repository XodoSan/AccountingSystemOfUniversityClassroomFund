﻿namespace Domain.Entities
{
    public class FinanciallyResponsiblePersonChangeHistory
    {
        public int Id { get; set; }
        public DateTimeOffset ChangeTime { get; set; }
        public int PreviousFinanciallyResponsiblePersonId { get; set; }
        public int CurrentFinanciallyResponsiblePersonId { get; set; }
    }
}