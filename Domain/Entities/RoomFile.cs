namespace Domain.Entities
{
    public class RoomFile
    {
        public RoomFile(string fileName, byte[] content, int currentRoomNumber)
        {
            FileName = fileName;
            Content = content;
            CurrentRoomNumber = currentRoomNumber;
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public int CurrentRoomNumber { get; set; }
    }
}
