using Xunit;
using VehicleBidCalculator.Application.Services;
using VehicleBidCalculator.Domain.Enums;
using Microsoft.Extensions.Logging;
using Moq;

namespace VehicleBidCalculator.Application.Tests.Services
{
    public class CalculationServiceTests
    {
        private readonly CalculationService _service;
        private readonly Mock<ILogger<CalculationService>> _loggerMock;

        public CalculationServiceTests()
        {
            _loggerMock = new Mock<ILogger<CalculationService>>();
            _service = new CalculationService(_loggerMock.Object);
        }

        [Theory]
        [InlineData(398, VehicleType.Common, 550.76)]
        [InlineData(501, VehicleType.Common, 671.02)]
        [InlineData(57, VehicleType.Common, 173.14)]
        [InlineData(1800, VehicleType.Luxury, 2167.00)]
        [InlineData(1100, VehicleType.Common, 1287.00)]
        [InlineData(1000000, VehicleType.Luxury, 1040320.00)]
        public void CalculateTotalPrice_ShouldReturnCorrectTotal(decimal basePrice, VehicleType vehicleType, decimal expectedTotal)
        {
            // Arrange

            // Act
            var totalPrice = _service.CalculateTotalPrice(basePrice, vehicleType);

            // Assert
            Assert.Equal(expectedTotal, totalPrice);
        }
    }
}
