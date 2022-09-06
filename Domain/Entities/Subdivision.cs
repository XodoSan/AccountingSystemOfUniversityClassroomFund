using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Subdivision
    {
        [Key]
        public string FacultyName { get; set; }
    }
}
