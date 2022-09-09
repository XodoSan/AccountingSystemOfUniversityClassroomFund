using Domain.Constants;

namespace Domain.Entities
{
    public class Room
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public Purpose Purpose { get; set; }
        public RoomType RoomType { get; set; }
        public int Area { get; set; }
        public string FloorPlan { get; set; }
        public Subdivision Owner { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string SubdivisionName { get; set; }
        public string UniversityName { get; set; }
    }
}
