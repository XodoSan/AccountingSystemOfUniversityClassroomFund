using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class AuditoriumFundService : IAuditoriumFundService
    {
        private readonly IAuditoriumFundRepository _fundRepository;

        public AuditoriumFundService(IAuditoriumFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public List<Room> GetAllRooms()
        {
            return _fundRepository.GetAllRooms();
        }
    }
}
