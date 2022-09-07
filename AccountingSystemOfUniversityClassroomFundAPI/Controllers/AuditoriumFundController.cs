using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuditoriumFundController : ControllerBase
    {
        private readonly IAuditoriumFundService _fundService;

        public AuditoriumFundController(IAuditoriumFundService fundService)
        {
            _fundService = fundService;
        }

        [HttpGet]
        public List<Room> GetAllRooms()
        {
            return _fundService.GetAllRooms();
        }
    }
}
