namespace Domain.Entities
{
    public class UniversityBuilding
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public int StoreysNumber { get; set; }
        public int FoundationYear { get; set; }
        public List<Room> IncomingRooms { get; set; }
        public List<Subdivision> IncomingSubdivisions { get; set; }
    }
}
