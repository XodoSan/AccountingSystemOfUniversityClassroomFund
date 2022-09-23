using Application.DTOs;
using AutoMapper;
using Domain.Constants;
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

            string currentFilePath = Constant.BaseFileAccessPath + universityName + "/Rooms/" + room.Number + "/";
            Directory.CreateDirectory(currentFilePath);
            AddFileInDirectory(roomDTO.FloorPlan, currentFilePath);

            room.UniversityName = universityName;
            room.Owner.UniversityName = universityName;
            room.FloorPlan = currentFilePath;

            _fundRepository.AddRoom(room);
        }

        public void AddUniversityBuilding(UniversityBuildingDTO universityBuildingDTO)
        {
            UniversityBuilding universityBuilding = _mapper
                .Map<UniversityBuilding>(universityBuildingDTO);

            string currentFilePath = Constant.BaseFileAccessPath + universityBuilding.Name + "/Rooms/";
            Directory.CreateDirectory(currentFilePath);

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
            Room room = _fundRepository.GetRoomByNumber(Convert.ToInt32(roomDTO.Number));
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

            string currentFilePath = Constant.BaseFileAccessPath + currentRoom.UniversityName + "/" + roomNumber;
            Directory.Delete(currentFilePath);

            _fundRepository.DeleteRoom(currentRoom);
        }

        public void DeleteUniversityBuildingByName(string universityName)
        {
            string currentFilePath = Constant.BaseFileAccessPath + universityName;
            Directory.Delete(currentFilePath);

            UniversityBuilding currentUniversity = _fundRepository.GetUniversityBuildingByName(universityName);
            _fundRepository.DeleteUniversityBuilding(currentUniversity);
        }

        public void AddFileInDirectory(IFormFile file, string currentFilePath)
        {
            using(Stream fileStream = new FileStream(currentFilePath + file.FileName, FileMode.Create))
            {
                file.CopyToAsync(fileStream);
                fileStream.Close();
            }
        }
    }
}