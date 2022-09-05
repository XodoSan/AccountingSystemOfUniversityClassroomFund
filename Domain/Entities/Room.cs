using Domain.Constants;

namespace Domain.Entities
{
    public class Room
    {
        public string Name { get; set; }
        public bool Purpose { get; set; }
        public RoomType RoomType { get; set; }
        public int Area { get; set; }
        public string FloorPlan { get; set; }
        public string Owner { get; set; }
        public int Capacity { get; set; }
        public string Floor { get; set; }
        public int Number { get; set; }
    }
}
