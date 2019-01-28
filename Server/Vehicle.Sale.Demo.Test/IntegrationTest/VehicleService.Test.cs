using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using VehicleSale.Demo.Datastore;
using VehicleSale.Demo.Model;
using VehicleSale.Demo.Service;
using Xunit;

namespace VehicleSale.Demo.IntegrationTest
{
    public class VehicleServiceIntegrationTest : IDisposable
    {
        IVehicleStrategyContext vehicleStrategyContext;
        IDbService dbService;
        IVehicleConverter vehicleConverter;
        ICarService carService;
        IBoatService boatService;
        DataContext dataContext;

        public VehicleServiceIntegrationTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().EnableSensitiveDataLogging(true).UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            dataContext = new DataContext(options);
            vehicleStrategyContext = new VehicleStrategyContext();
            boatService = new BoatService(dataContext);
            carService = new CarService(dataContext);
            dbService = new DbService(carService, boatService);
            vehicleConverter = new VehicleConverter();
        }
        public void Dispose()
        {
            vehicleStrategyContext = null;
            dbService = null;
            vehicleConverter = null;
            carService = null;
            boatService = null;
            dataContext = null;
        }

        [Fact]
        public void GetVehicleTypes_returns_all_vehicles()
        {
            //given
            var sut = new VehicleService(vehicleStrategyContext, dbService, vehicleConverter);

            //when
            var result = sut.GetVehicleTypes();

            //then
            Assert.IsAssignableFrom<IEnumerable<string>>(result);
        }

        [Fact]
        public void GetVehicleProperties_returns_all_vehicles_properties()
        {
            //given
            var sut = new VehicleService(vehicleStrategyContext, dbService, vehicleConverter);

            //when
            var result = sut.GetVehicleProperties("car");
            //
            Assert.IsAssignableFrom<IEnumerable<VehicleInfo>>(result.Result);

        }
        [Fact]
        public void AddVehicle_adds_the_vehicle_with_properties()
        {
            //given
            var sut = new VehicleService(vehicleStrategyContext, dbService, vehicleConverter);

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
            var sut = new VehicleService(vehicleStrategyContext, dbService, vehicleConverter);
            JObject carObject = JObject.FromObject(new Car()
            {
                Make = "JEEP",
                Id = 1,
                Model = "Cherokee",
                Doors = 4,
                Wheels = 4,
                BodyType = "SUV",
                Engine = "1000CC"
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
            var sut = new VehicleService(vehicleStrategyContext, dbService, vehicleConverter);

            //when
            var result = sut.GetAllVehicles();

            //then
            Assert.IsAssignableFrom<IEnumerable<Vehicle>>(result.Result);
        }

        [Fact]
        public void GetSpecificVehicle_returns_specific_vehicle()
        {
            string vechiclType = "CAR";
            int Id = 1;

            //given 
            var sut = new VehicleService(vehicleStrategyContext, dbService, vehicleConverter);

            //when
            var result = sut.GetSpecificVehicle(vechiclType, Id);

            //then
            Assert.IsAssignableFrom<Vehicle>(result.Result);

        }
    }
}
