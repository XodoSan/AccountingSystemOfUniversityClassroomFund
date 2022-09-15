using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClassroomFundRepository
    {
        public List<Room> GetAllCurrentUniversityRooms(string universityName);
        public Room GetRoomByNumber(int roomNumber);
        public UniversityBuilding GetUniversityBuildingByName(string universityName);
        public void AddRoom(Room room);
        public void AddUniversityBuilding(UniversityBuilding universityBuilding);
        public void AddSubdivision(Subdivision subdivision);
        public void DeleteRoom(Room currentRoom);
        public void DeleteUniversityBuilding(UniversityBuilding currentUniversity);
    }
}
