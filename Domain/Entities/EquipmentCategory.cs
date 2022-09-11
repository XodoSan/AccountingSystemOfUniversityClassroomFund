﻿namespace Domain.Entities
{
    public class EquipmentCategory
    {
        public string Name { get; set; }
        public int EquipmentAmount { get; set; }
        public List<Equipment> CurrentCategoryEquipments { get; set; }
    }
}