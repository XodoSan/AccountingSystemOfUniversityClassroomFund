using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemOfUniversityClassroomFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {
        [HttpGet]
        public string InitMethod()
        {
            return "Init controller works!";
        }
    }
}