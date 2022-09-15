using Application.DTOs;
using Domain.Entities;

namespace Application.Services.ClassroomFundService
{
    public interface IClassroomFundService
    {
        public List<Room> GetAllCurrentUniversityRooms(string universityName);
        public void AddRoomInUniversity(string universityName, RoomDTO roomDTO);
        public void AddUniversityBuilding(UniversityBuildingDTO universityBuildingDTO);
        public void AddSubdivisionInUniversity(string universityName, SubdivisionDTO subdivisionDTO);
        public void UpdateRoom(string universityName, RoomDTO roomDTO);
        public void UpdateUniversityBuilding(UniversityBuildingDTO universityBuildingDTO);
        public void DeleteRoomByNumber(int roomNumber);
        public void DeleteUniversityBuildingByName(string universityName);
    }
}
