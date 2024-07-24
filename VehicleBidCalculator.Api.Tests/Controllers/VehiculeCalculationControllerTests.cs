using MediatR;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleBidCalculator.Api.Controllers;
using VehicleBidCalculator.Application.Queries;
using VehicleBidCalculator.Domain.Enums;
using VehicleBidCalculator.Domain.Models;
using System.Threading.Tasks;

namespace VehicleBidCalculator.Api.Tests.Controllers
{
    public class VehiculeCalculationControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<VehiculeCalculationController>> _loggerMock;
        private readonly VehiculeCalculationController _controller;

        public VehiculeCalculationControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<VehiculeCalculationController>>();
            _controller = new VehiculeCalculationController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetTotalPrice_ShouldReturnOkResult_WithValidInput_ForCommonVehicle()
        {
            // Arrange
            var query = new GetVehicleTotalPriceQuery { BasePrice = 1000, VehicleType = VehicleType.Common };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetVehicleTotalPriceQuery>(), default))
                         .ReturnsAsync(new VehicleTotalPriceResponse { TotalPrice = 1500 });

            // Act
            var result = await _controller.GetTotalPrice(1000, VehicleType.Common);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<VehicleTotalPriceResponse>(okResult.Value);
            Assert.Equal(1500m, returnValue.TotalPrice);
        }

        [Fact]
        public async Task GetTotalPrice_ShouldReturnOkResult_WithValidInput_ForLuxuryVehicle()
        {
            // Arrange
            var query = new GetVehicleTotalPriceQuery { BasePrice = 2000, VehicleType = VehicleType.Luxury };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetVehicleTotalPriceQuery>(), default))
                         .ReturnsAsync(new VehicleTotalPriceResponse { TotalPrice = 2500 });

            // Act
            var result = await _controller.GetTotalPrice(2000, VehicleType.Luxury);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<VehicleTotalPriceResponse>(okResult.Value);
            Assert.Equal(2500m, returnValue.TotalPrice);
        }
    }
}
