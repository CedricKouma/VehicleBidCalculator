using VehicleBidCalculator.Domain.Enums;

namespace VehicleBidCalculator.Application.Services
{
    public interface ICalculationService
    {
        decimal CalculateTotalPrice(decimal basePrice, VehicleType vehicleType);
    }
}