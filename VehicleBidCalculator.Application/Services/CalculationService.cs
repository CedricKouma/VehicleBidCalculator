using Microsoft.Extensions.Logging;
using VehicleBidCalculator.Domain.Enums;

namespace VehicleBidCalculator.Application.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ILogger<CalculationService> _logger;

        private const decimal CommonBasicFeeMin = 10m;
        private const decimal CommonBasicFeeMax = 50m;
        private const decimal LuxuryBasicFeeMin = 25m;
        private const decimal LuxuryBasicFeeMax = 200m;
        private const decimal BasicFeePercentage = 0.10m;

        private const decimal CommonSpecialFeePercentage = 0.02m;
        private const decimal LuxurySpecialFeePercentage = 0.04m;

        private const decimal AssociationFeeTier1 = 5m;
        private const decimal AssociationFeeTier2 = 10m;
        private const decimal AssociationFeeTier3 = 15m;
        private const decimal AssociationFeeTier4 = 20m;

        private const decimal AssociationFeeLimit1 = 500m;
        private const decimal AssociationFeeLimit2 = 1000m;
        private const decimal AssociationFeeLimit3 = 3000m;

        private const decimal StorageFee = 100m;

        public CalculationService(ILogger<CalculationService> logger)
        {
            _logger = logger;
        }



        public decimal CalculateTotalPrice(decimal basePrice, VehicleType vehicleType)
        {
            _logger.LogInformation($"Calculating total price for vehicleType: {vehicleType} with basePrice: {basePrice}");

            decimal basicBuyerFee;
            decimal specialFee;
            decimal associationFee;

            // Basic buyer fee
            if (vehicleType == VehicleType.Common)
            {
                basicBuyerFee = Math.Min(Math.Max(basePrice * BasicFeePercentage, CommonBasicFeeMin), CommonBasicFeeMax);
                specialFee = basePrice * CommonSpecialFeePercentage;
            }
            else
            {
                basicBuyerFee = Math.Min(Math.Max(basePrice * BasicFeePercentage, LuxuryBasicFeeMin), LuxuryBasicFeeMax);
                specialFee = basePrice * LuxurySpecialFeePercentage;
            }

            // Association fee
            if (basePrice <= AssociationFeeLimit1)
            {
                associationFee = AssociationFeeTier1;
            }
            else if (basePrice <= AssociationFeeLimit2)
            {
                associationFee = AssociationFeeTier2;
            }
            else if (basePrice <= AssociationFeeLimit3)
            {
                associationFee = AssociationFeeTier3;
            }
            else
            {
                associationFee = AssociationFeeTier4;
            }

            // Total price calculation
            decimal totalPrice = basePrice + basicBuyerFee + specialFee + associationFee + StorageFee;
            _logger.LogInformation($"Total price calculated: {totalPrice}");
            return totalPrice;
        }
    }
}
