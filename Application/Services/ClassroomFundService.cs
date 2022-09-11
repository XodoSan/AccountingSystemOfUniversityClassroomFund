using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class ClassroomFundService : IClassroomFundService
    { 
        private readonly IClassroomFundRepository _fundRepository;
        private readonly IMapper _mapper;

        public ClassroomFundService(IClassroomFundRepository fundRepository, IMapper mapper)
        {
            _fundRepository = fundRepository;
            _mapper = mapper;
        }

        public List<Room> GetAllCurrentUniversityRooms(string universityName)
        {
            return _fundRepository.GetAllCurrentUniversityRooms(universityName);
        }

        public void AddRoom(string universityName, RoomDTO roomDTO)
        {
            Room room = _mapper.Map<Room>(roomDTO);
            room.UniversityName = universityName;

            _fundRepository.AddRoom(room);
        }

        public void AddUniversityBuilding(UniversityBuildingDTO universityBuildingDTO)
        {
            UniversityBuilding universityBuilding = _mapper.Map<UniversityBuilding>(universityBuildingDTO);
            _fundRepository.AddUniversityBuilding(universityBuilding);
        }
    }
}
