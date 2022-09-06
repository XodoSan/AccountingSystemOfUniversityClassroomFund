using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UniversityBilding
    {
        [Key]
        public string Name { get; set; }
        public string Adress { get; set; }
        public int StoreysNumber { get; set; }
        public int FoundationYear { get; set; }
    }
}
