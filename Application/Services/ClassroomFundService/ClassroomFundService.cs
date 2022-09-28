using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Services.ClassroomFundService
{
    public class ClassroomFundService : IClassroomFundService, IFileService
    {
        private readonly IClassroomFundRepository _fundRepository;
        private readonly IMapper _mapper;

        public ClassroomFundService(IClassroomFundRepository fundRepository, IMapper mapper)
        {
            _fundRepository = fundRepository;
            _mapper = mapper;
        }

        public void AddRoomInUniversity(string universityName, RoomDTO roomDTO)
        {
            Room room = _mapper.Map<Room>(roomDTO);
            byte[] byteFile = ConvertFileToByteArray(roomDTO.FloorPlan);

            room.UniversityName = universityName;
            room.Owner.UniversityName = universityName;
            room.FloorPlan = new RoomFile(roomDTO.FloorPlan.FileName, byteFile, room.Number);

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

        public void UpdateRoom(RoomDTO roomDTO)
        {
            Room room = _fundRepository.GetRoomByNumber(Convert.ToInt32(roomDTO.Number));
            _mapper.Map(roomDTO, room);

            RoomFile roomFile = _fundRepository.GetRoomFileByRoomNumber(room.Number);
            byte[] byteFile = ConvertFileToByteArray(roomDTO.FloorPlan);

            roomFile = new RoomFile(roomDTO.FloorPlan.FileName, byteFile, room.Number);
            room.FloorPlan = roomFile;
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

        public void DeleteUniversityBuildingByName(string universityName)
        {
            UniversityBuilding currentUniversity = _fundRepository.GetUniversityBuildingByName(universityName);
            _fundRepository.DeleteUniversityBuilding(currentUniversity);
        }

        public byte[] ConvertFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyToAsync(memoryStream);
                byte[] binaryFile = memoryStream.ToArray();

                return binaryFile;
            }
        }
    }
}