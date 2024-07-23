using Microsoft.AspNetCore.Mvc;
using MediatR;
using VehicleBidCalculator.Domain.Enums;
using VehicleBidCalculator.Application.Queries;

namespace VehicleBidCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculeCalculationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<VehiculeCalculationController> _logger;

        public VehiculeCalculationController(IMediator mediator, ILogger<VehiculeCalculationController> logger){
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("getTotalPrice")]
        public async Task<IActionResult> GetTotalPrice([FromQuery] decimal basePrice, [FromQuery] VehicleType vehicleType)
        {
            var query = new GetVehicleTotalPriceQuery(){
                BasePrice = basePrice,
                VehicleType = vehicleType
            };
            var totalPrice = await _mediator.Send(query);
            return Ok(new { TotalPrice = totalPrice });
        }
    }
}