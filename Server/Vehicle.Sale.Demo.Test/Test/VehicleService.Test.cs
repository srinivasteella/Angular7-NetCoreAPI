using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleSale.Demo.Datastore;
using VehicleSale.Demo.Model;
using VehicleSale.Demo.Service;
using Xunit;

namespace VehicleSale.Demo.UnitTest
{
    public class VehicleServiceTest : IDisposable
    {
        Mock<IVehicleStrategyContext> moqVehicleStrategyContext;
        Mock<IDbService> moqDbService;
        Mock<IVehicleConverter> moqVehicleConverter;

        public VehicleServiceTest()
        {
            moqVehicleStrategyContext = new Mock<IVehicleStrategyContext>();
            moqDbService = new Mock<IDbService>();
            moqVehicleConverter = new Mock<IVehicleConverter>();
        }
        public void Dispose()
        {
            moqVehicleStrategyContext = null;
        }

        [Fact]
        public void GetVehicleTypes_returns_all_vehicles()
        {
            //given
            var sut = new VehicleService(moqVehicleStrategyContext.Object, moqDbService.Object, moqVehicleConverter.Object);
            //when
            var result = sut.GetVehicleTypes();
            //
            Assert.IsAssignableFrom<IEnumerable<string>>(result);
        }

        [Fact]
        public void GetVehicleProperties_returns_all_vehicles_properties()
        {
            //given
            moqVehicleStrategyContext.Setup(m => m.GetVehicleProperties(It.IsAny<VehicleType>())).Returns(Task.FromResult<IEnumerable<VehicleInfo>>(new List<VehicleInfo>()));
            var sut = new VehicleService(moqVehicleStrategyContext.Object, moqDbService.Object, moqVehicleConverter.Object);
            //when
            var result = sut.GetVehicleProperties("car");
            //
            Assert.IsAssignableFrom<IEnumerable<VehicleInfo>>(result.Result);

        }
        [Fact]
        public void AddVehicle_adds_the_vehicle_with_properties()
        {
            //given
            moqVehicleConverter.Setup(m => m.Convert(It.IsAny<JObject>())).Returns(new Car());
            moqDbService.Setup(m => m.AddVehicle(It.IsAny<Vehicle>())).Returns(Task.FromResult<string>("success"));

            var sut = new VehicleService(moqVehicleStrategyContext.Object, moqDbService.Object, moqVehicleConverter.Object);
            JObject carObject = JObject.FromObject(new Car()
            {
                Make = "JEEP",
                Id = 1,
                Model = "Grand Cherokee",
                Doors = 5,
                Wheels = 6,
                BodyType = "SUV",
                Engine = "1000CC"
            });

            //when
            var result = sut.AddVehicle(carObject);

            //then
            Assert.IsAssignableFrom<string>(result.Result);
        }
        [Fact]
        public void UpdateVehicle_updates_the_vehicle_with_properties()
        {
            //given
            moqVehicleConverter.Setup(m => m.Convert(It.IsAny<JObject>())).Returns(new Car());
            moqDbService.Setup(m => m.UpdateVehicle(It.IsAny<Vehicle>())).Returns(Task.FromResult<string>("success"));
            var sut = new VehicleService(moqVehicleStrategyContext.Object, moqDbService.Object, moqVehicleConverter.Object);
            JObject carObject = JObject.FromObject(new Car()
            {
                Make = "toyota",
                Id = 1,
                Model = "sedan",
                Doors = 2,
                Wheels = 4
            });

            //when
            var result = sut.UpdateVehicle(carObject);

            //then
            Assert.IsAssignableFrom<string>(result.Result);

        }
        [Fact]
        public void GetAllVehicles_returns_all_vehicles()
        {
            //given
            moqDbService.Setup(m => m.GetAllVehicles()).Returns(Task.FromResult<IEnumerable<Vehicle>>(new List<Vehicle>()));
            var sut = new VehicleService(moqVehicleStrategyContext.Object, moqDbService.Object, moqVehicleConverter.Object);

            //when
            var result = sut.GetAllVehicles();

            //then
            Assert.IsAssignableFrom<IEnumerable<Vehicle>>(result.Result);
        }

        [Fact]
        public void GetSpecificVehicle_returns_specific_vehicle()
        {
            moqDbService.Setup(m => m.GetSpecificVehicle(It.IsAny<Vehicle>())).Returns(Task.FromResult<Vehicle>(new Car()));
            moqVehicleConverter.Setup(m => m.Convert(It.IsAny<JObject>())).Returns(new Car());

            //given 
            var sut = new VehicleService(moqVehicleStrategyContext.Object, moqDbService.Object, moqVehicleConverter.Object);

            JObject carObject = JObject.FromObject(new Car()
            {
                Id = 1
            });
            //when
            var result = sut.GetSpecificVehicle(carObject);

            //then
            Assert.IsAssignableFrom<Vehicle>(result.Result);

        }
    }
}
