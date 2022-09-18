using Application.DTOs;

namespace Application.Services.HistoryService
{
    public interface IHistoryService
    {
        public List<EquipmentMovementHistoryDTO> GetMovementHistory();
        public List<EquipmentFinanciallyResponsiblePersonChangeHistoryDTO> GetChangeWorkerHistory();
    }
}