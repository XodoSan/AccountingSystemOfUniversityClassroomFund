namespace Domain.Entities
{
    public class Subdivision
    {
        public string Name { get; set; }
        public List<Room> IncomingRooms { get; set; }
        public List<Worker> IncomingWorkers { get; set; }
    }
}
