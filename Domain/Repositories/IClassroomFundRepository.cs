using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClassroomFundRepository
    {
        public List<Room> GetAllCurrentUniversityRooms(string universityName);
        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber);
        public void AddRoom(Room room);
    }
}
