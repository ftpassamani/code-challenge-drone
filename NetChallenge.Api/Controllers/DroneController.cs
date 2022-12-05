using Microsoft.AspNetCore.Mvc;
using NetChallenge.Api.Models;
using NetChallenge.Api.Services.Interfaces;

namespace NetChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroneController : ControllerBase
    {
        private readonly IDroneService _droneService;

        public DroneController(IDroneService droneService)
        {
            _droneService = droneService;
        }

        [HttpPost()]
        public async Task<ActionResult> CreateAsync([FromBody] Input request)
        {
            var response = await _droneService.CreateAsync(request);
            return Ok(response);
        }
    }
}
