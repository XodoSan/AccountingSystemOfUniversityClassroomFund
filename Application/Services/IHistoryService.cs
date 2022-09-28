using Application.DTOs;

namespace Application.Services
{
    public interface IHistoryService
    {
        public List<EquipmentMovementHistoryItemDTO> GetMovementHistory();
        public List<EquipmentFinanciallyResponsiblePersonChangeHistoryItemDTO> GetChangeWorkerHistory();
    }
}