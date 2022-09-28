using Application.DTOs;

namespace Application.Services.ClassroomFundService
{
    public interface IClassroomFundService
    {
        public void AddRoomInUniversity(string universityName, RoomDTO roomDTO);
        public void AddUniversityBuilding(UniversityBuildingDTO universityBuildingDTO);
        public void AddSubdivisionInUniversity(string universityName, SubdivisionDTO subdivisionDTO);
        public void UpdateRoom(RoomDTO roomDTO);
        public void UpdateUniversityBuilding(UniversityBuildingDTO universityBuildingDTO);
        public void DeleteRoomByNumber(int roomNumber);
        public void DeleteUniversityBuildingByName(string universityName);
    }
}
