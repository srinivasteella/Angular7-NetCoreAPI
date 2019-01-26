using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using VehicleSale.Demo.Datastore;
using VehicleSale.Demo.Model;
using VehicleSale.Demo.Service;
using Xunit;

namespace VehicleSale.Demo.UnitTest
{
    public class VehicleConverterTest : IDisposable
    {
        JObject carObject;
        public VehicleConverterTest()
        {
            carObject = JObject.FromObject(new Car()
            {
                Make = "JEEP",
                Id = 1,
                Model = "Grand Cherokee",
                Doors = 5,
                Wheels = 6,
                BodyType = "SUV",
                Engine = "1000CC"
            });
        }
        public void Dispose()
        {
            carObject = null;
        }

        [Fact]
        public void Convert_returns_vehicle_of_the_specific_type()
        {
            //given
            var sut = new VehicleConverter();

            //when
            var result = sut.Convert(carObject);

            //then
            Assert.IsAssignableFrom<Car>(result);
        }
    }
}
