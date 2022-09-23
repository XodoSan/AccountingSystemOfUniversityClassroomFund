using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class RoomDTO
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string RoomType { get; set; }
        public string Area { get; set; }
        public IFormFile FloorPlan { get; set; }
        public SubdivisionDTO ?Owner { get; set; }
        public string Capacity { get; set; }
        public string Floor { get; set; }
    }
}
