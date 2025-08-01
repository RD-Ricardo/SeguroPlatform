using Hiring.Application.Ports.Inbound.UseCases.GetAllHirings;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Api.Controllers
{
    [ApiController]
    [Route("api/hirings")]
    public class HiringController : ControllerBase
    {
        private readonly ILogger<HiringController> _logger;
        public HiringController(ILogger<HiringController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetAllHiringsUseCase getAllHiringsUseCase)
        {
            var result = await getAllHiringsUseCase.ExecuteAsync();
            return Ok(result);
        }
    }
}
