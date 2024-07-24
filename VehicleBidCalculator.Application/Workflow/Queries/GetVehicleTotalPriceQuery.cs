using MediatR;
using VehicleBidCalculator.Domain.Enums;
using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Application.Queries
{
    public class GetVehicleTotalPriceQuery : IRequest<VehicleTotalPriceResponse>
    {
        public decimal BasePrice { get; set; }
        public VehicleType VehicleType { get; set; } = VehicleType.Common;
    }
}