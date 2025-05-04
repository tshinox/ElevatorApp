using Elevator.App.Models.DTOs.Requests;
using ElevatorAppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProximityCheckWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitController : Controller
    {
        private readonly ILogger<LimitController> _logger;
        private readonly ILimitCheckService _limitCheckService;

        public LimitController(ILogger<LimitController> logger,
            ILimitCheckService limitCheckService)
        {
            _limitCheckService = limitCheckService;
            _logger = logger;
        }

        [HttpPost("CheckPassengerLimit")]
        public async Task<IActionResult> CheckPassengerLimit([FromBody] DestinationRequest request)
        {
            try
            {
                var result = await _limitCheckService.CheckPassengerLimit(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost("CheckWeightLimit")]
        public async Task<IActionResult> CheckWeightLimit([FromBody] DestinationRequest request)
        {
            try
            {
                var result = await _limitCheckService.CheckWeightLimit(request);
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
