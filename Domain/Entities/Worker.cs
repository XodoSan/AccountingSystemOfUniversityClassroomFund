using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }
}
