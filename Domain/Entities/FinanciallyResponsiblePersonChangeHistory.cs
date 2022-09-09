using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class FinanciallyResponsiblePersonChangeHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime ChangeTime { get; set; }
        [Required]
        [ForeignKey("MovedEquipment")]
        public Equipment MovedEquipment { get; set; }
        [Required]
        [ForeignKey("PreviousFinanciallyResponsiblePerson")]
        public Worker PreviousFinanciallyResponsiblePerson { get; set; }
        [Required]
        [ForeignKey("CurrentFinanciallyResponsiblePerson")]
        public Worker CurrentFinanciallyResponsiblePerson { get; set; }
    }
}