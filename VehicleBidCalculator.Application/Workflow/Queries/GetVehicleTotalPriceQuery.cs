using MediatR;
using VehicleBidCalculator.Domain.Enums;

namespace VehicleBidCalculator.Application.Queries
{
    public class GetVehicleTotalPriceQuery : IRequest<decimal>
    {
        public decimal BasePrice { get; set; }
        public VehicleType VehicleType { get; set; } = VehicleType.Common;
    }
}