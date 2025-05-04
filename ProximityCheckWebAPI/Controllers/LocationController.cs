using Elevator.App.Models.DTOs.Requests;
using ElevatorAppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProximityCheckWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;
        private readonly IProximityCheckService _proximityCheckService;

        public LocationController(ILogger<LocationController> logger,
            IProximityCheckService payerService)
        {
            _proximityCheckService = payerService;
            _logger = logger;
        }

        [HttpPost("CallElevator")]
        public async Task<IActionResult> GetClosestElevator([FromQuery] FloorRequest request)
        {
            try
            {
                var result = await _proximityCheckService.GetClosestElevator(request);
                return Ok("Elevator "+result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

    }
}
