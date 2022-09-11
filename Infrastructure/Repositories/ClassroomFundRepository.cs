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
    }
}
