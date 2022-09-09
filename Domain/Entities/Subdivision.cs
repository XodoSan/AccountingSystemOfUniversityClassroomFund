using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Subdivision
    {
        [Key]
        public string Name { get; set; }
        public List<Room> IncomingRooms { get; set; }
    }
}
