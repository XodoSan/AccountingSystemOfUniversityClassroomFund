using Application.DTOs;

namespace Application.Services.EquipmentService
{
    public interface IEquipmentService
    {
        public void AddEquipmentInRoom(int roomNumber, EquipmentDTO equipmentDTO);
    }
}
