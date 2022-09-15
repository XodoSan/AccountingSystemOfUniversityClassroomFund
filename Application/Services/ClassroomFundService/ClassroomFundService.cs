using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.ClassroomFundService
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

        public void AddRoomInUniversity(string universityName, RoomDTO roomDTO)
        {
            Room room = _mapper.Map<Room>(roomDTO);
            room.UniversityName = universityName;
            room.Owner.UniversityName = universityName;

            _fundRepository.AddRoom(room);
        }

        public void AddUniversityBuilding(UniversityBuildingDTO universityBuildingDTO)
        {
            UniversityBuilding universityBuilding = _mapper
                .Map<UniversityBuilding>(universityBuildingDTO);
            _fundRepository.AddUniversityBuilding(universityBuilding);
        }

        public void AddSubdivisionInUniversity(string universityName, SubdivisionDTO subdivisionDTO)
        {
            Subdivision subdivision = _mapper.Map<Subdivision>(subdivisionDTO);
            subdivision.UniversityName = universityName;
            _fundRepository.AddSubdivision(subdivision);
        }

        public void UpdateRoom(string universityName, RoomDTO roomDTO)
        {
            Room room = _fundRepository.GetRoomByNumber(roomDTO.Number);
            _mapper.Map(roomDTO, room);
        }

        public void UpdateUniversityBuilding(UniversityBuildingDTO universityBuildingDTO)
        {
            UniversityBuilding universityBuilding = _fundRepository.GetUniversityBuildingByName(universityBuildingDTO.Name);
            _mapper.Map(universityBuildingDTO, universityBuilding);
        }

        public void DeleteRoomByNumber(int roomNumber)
        {
            Room currentRoom = _fundRepository.GetRoomByNumber(roomNumber);
            _fundRepository.DeleteRoom(currentRoom);
        }
    }
}