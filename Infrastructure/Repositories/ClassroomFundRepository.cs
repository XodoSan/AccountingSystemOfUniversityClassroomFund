using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class ClassroomFundRepository : IClassroomFundRepository
    {
        private AppDBContext _context;

        public ClassroomFundRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<Room> GetAllCurrentUniversityRooms(string universityName)
        {
            return _context.Set<Room>()
                .Where(room => room.UniversityName == universityName)
                .ToList();
        }

        public Room GetRoomByNumber(int roomNumber)
        {
            return _context.Set<Room>()
                .Where(room => room.Number == roomNumber)
                .First();
        }

        public UniversityBuilding GetUniversityBuildingByName(string universityName)
        {
            return _context.Set<UniversityBuilding>()
                .Where(university => university.Name == universityName)
                .First();
        }

        public void AddRoom(Room room)
        {
            _context.Set<Room>().Add(room);
        }

        public void AddUniversityBuilding(UniversityBuilding universityBuilding)
        {
            _context.Set<UniversityBuilding>().Add(universityBuilding);
        }

        public void AddSubdivision(Subdivision subdivision)
        {
            _context.Set<Subdivision>().Add(subdivision);
        }

        public void DeleteRoom(Room currentRoom)
        {
            _context.Set<Room>().Remove(currentRoom);
        }

        public void DeleteUniversityBuilding(UniversityBuilding currentUniversity)
        {
            _context.Set<UniversityBuilding>().Remove(currentUniversity);
        }
    }
}
