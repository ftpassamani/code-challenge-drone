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
            if (!request.DronesAssigned.Any())
            {
                return BadRequest("There is no drones");
            }

            if (request.DronesAssigned.Count > 100)
            {
                return BadRequest("Max number of Drones is 100");
            }

            var response = await _droneService.CreateAsync(request);
            return Ok(response);
        }

        [HttpGet()]
        public async Task<ActionResult> GetAsync()
        {
            var response = await _droneService.GetAsync();
            return Ok(response);
        }
    }
}
