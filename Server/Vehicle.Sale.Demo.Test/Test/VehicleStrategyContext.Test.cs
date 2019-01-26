using Moq;
using System;
using System.Collections.Generic;
using VehicleSale.Demo.Model;
using VehicleSale.Demo.Service;
using Xunit;

namespace VehicleSale.Demo.UnitTest
{
    public class VehicleStrategyContextTest
    {

        [Fact]
        public void GetVehicleProperties_returns_all_vehicles_properties_with_help_of_dictionary()
        {
            //given
            var sut = new VehicleStrategyContext();

            //when
            var result = sut.GetVehicleProperties(VehicleType.CAR);

            //
            Assert.IsAssignableFrom<IEnumerable<VehicleInfo>>(result);
        }

        [Fact]
        public void GetVehicleType_returns_all_vehicle_type()
        {
            //given
            var sut = new VehicleStrategyContext();

            //when
            var result = sut.GetVehicleType(VehicleType.CAR);

            //
            Assert.IsAssignableFrom<Car>(result);
        }
    }
}
