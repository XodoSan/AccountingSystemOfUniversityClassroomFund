using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class AuditoriumFundRepository : IAuditoriumFundRepository
    {
        private AppDBContext _context;

        public AuditoriumFundRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<Room> GetAllRooms()
        {
            return _context.Set<Room>().ToList();
        }
    }
}
