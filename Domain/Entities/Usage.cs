using Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Usage
    {
        [Key]
        public int Id { get; set; }
        public string Instruction { get; set; }
        public Purpose Purpose { get; set; }
    }
}
