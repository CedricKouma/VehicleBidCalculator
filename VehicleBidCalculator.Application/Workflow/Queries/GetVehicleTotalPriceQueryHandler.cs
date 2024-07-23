using MediatR;
using Microsoft.Extensions.Logging;
using VehicleBidCalculator.Application.Services;

namespace VehicleBidCalculator.Application.Queries
{
    public class GetVehicleTotalPriceQueryHandler : IRequestHandler<GetVehicleTotalPriceQuery, decimal>
    {
        private readonly ICalculationService _calculationService;
        private readonly ILogger<GetVehicleTotalPriceQueryHandler> _logger;


        public GetVehicleTotalPriceQueryHandler(ICalculationService calculationService, ILogger<GetVehicleTotalPriceQueryHandler> logger)
        {
            _calculationService = calculationService;
            _logger = logger;
        }

        public Task<decimal> Handle(GetVehicleTotalPriceQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling CalculateTotalPriceQuery for BasePrice: {request.BasePrice}, VehicleType: {request.VehicleType}");
            var totalPrice = _calculationService.CalculateTotalPrice(request.BasePrice, request.VehicleType);
            _logger.LogInformation($"Total price: {totalPrice}");
            return Task.FromResult(totalPrice);
        }
    }
}