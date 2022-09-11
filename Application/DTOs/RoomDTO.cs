namespace Application.DTOs
{
    public class RoomDTO
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string RoomType { get; set; }
        public int Area { get; set; }
        public string FloorPlan { get; set; }
        public SubdivisionDTO Owner { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
    }
}
