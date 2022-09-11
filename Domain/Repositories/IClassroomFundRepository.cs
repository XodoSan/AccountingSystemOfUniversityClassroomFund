using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClassroomFundRepository
    {
        public List<Room> GetAllCurrentUniversityRooms(string universityName);
        public void AddRoom(Room room);
        public void AddUniversityBuilding(UniversityBuilding universityBuilding);
        public void AddSubdivision(Subdivision subdivision);
    }
}
