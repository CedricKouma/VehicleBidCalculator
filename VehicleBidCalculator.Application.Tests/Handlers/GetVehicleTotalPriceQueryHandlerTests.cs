using Xunit;
using Moq;
using VehicleBidCalculator.Application.Queries;
using VehicleBidCalculator.Application.Services;
using VehicleBidCalculator.Domain.Enums;
using VehicleBidCalculator.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace VehicleBidCalculator.Application.Tests.Handlers
{
    public class GetVehicleTotalPriceQueryHandlerTests
    {
        private readonly Mock<ICalculationService> _calculationServiceMock;
        private readonly Mock<ILogger<GetVehicleTotalPriceQueryHandler>> _loggerMock;
        private readonly GetVehicleTotalPriceQueryHandler _handler;

        public GetVehicleTotalPriceQueryHandlerTests()
        {
            _calculationServiceMock = new Mock<ICalculationService>();
            _loggerMock = new Mock<ILogger<GetVehicleTotalPriceQueryHandler>>();
            _handler = new GetVehicleTotalPriceQueryHandler(_calculationServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnTotalPriceResponse_ForCommonVehicle()
        {
            // Arrange
            var query = new GetVehicleTotalPriceQuery { BasePrice = 1000, VehicleType = VehicleType.Common };
            _calculationServiceMock.Setup(s => s.CalculateTotalPrice(It.IsAny<decimal>(), It.IsAny<VehicleType>()))
                                   .Returns(1500m);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(1500m, result.TotalPrice);
        }

        [Fact]
        public async Task Handle_ShouldReturnTotalPriceResponse_ForLuxuryVehicle()
        {
            // Arrange
            var query = new GetVehicleTotalPriceQuery { BasePrice = 2000, VehicleType = VehicleType.Luxury };
            _calculationServiceMock.Setup(s => s.CalculateTotalPrice(It.IsAny<decimal>(), It.IsAny<VehicleType>()))
                                   .Returns(2500m);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2500m, result.TotalPrice);
        }
    }
}
