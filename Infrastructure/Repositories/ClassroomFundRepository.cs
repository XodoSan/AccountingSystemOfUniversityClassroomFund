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

        public List<Equipment> GetAllCurrentRoomEquipment(int roomNumber)
        {
            return _context.Set<Equipment>()
                .Where(equipment => equipment.RoomNumber == roomNumber)
                .ToList();
        }

        public void AddRoom(Room room)
        {
            _context.Set<Room>().Add(room);
        }
    }
}
