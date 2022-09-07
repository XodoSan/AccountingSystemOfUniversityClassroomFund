using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAuditoriumFundRepository
    {
        public List<Room> GetAllRooms();
    }
}
