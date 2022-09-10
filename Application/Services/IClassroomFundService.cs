using Application.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public interface IClassroomFundService
    {
        public List<Room> GetAllCurrentUniversityRooms(string universityName);
        public void AddRoom(string universityName, RoomDTO roomDTO);
    }
}
