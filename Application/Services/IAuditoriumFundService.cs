using Domain.Entities;

namespace Application.Services
{
    public interface IAuditoriumFundService
    {
        public List<Room> GetAllRooms();
    }
}
