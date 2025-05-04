using Elevator.App.Models.DTOs.Requests;
using ElevatorAppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProximityCheckWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : Controller
    {
        private readonly ILogger<ElevatorController> _logger;
        private readonly IElevatorStateService _elevatorStateService;

        public ElevatorController(ILogger<ElevatorController> logger,
            IElevatorStateService elevatorStateService)
        {
            _elevatorStateService = elevatorStateService;
            _logger = logger;
        }

        [HttpPost("GetElevatorStatus")]
        public async Task<IActionResult> GetElevatorStatus([FromQuery] ElevatorStateRequest request)
        {
            try
            {
                var result = await _elevatorStateService.GetElevatorStatus(request);
                return Ok("Elevator " + result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost("GetDestination")]
        public async Task<IActionResult> GetDestination([FromQuery] ElevatorStateRequest request)
        {
            try
            {
                var result = await _elevatorStateService.GetDestination(request);
                return Ok("Elevator " + result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

    }
}
