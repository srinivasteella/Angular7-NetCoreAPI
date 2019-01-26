using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IVehicleStrategyContext
    {
        Task<IEnumerable<VehicleInfo>> GetVehicleProperties(VehicleType vehicleType);
        Vehicle GetVehicleType(VehicleType vehicleType);

    }
    public class VehicleStrategyContext : IVehicleStrategyContext
    {
        Dictionary<VehicleType, Vehicle> vehicleDictionary = new Dictionary<VehicleType, Vehicle>();
        public VehicleStrategyContext()
        {
            vehicleDictionary.Add(VehicleType.CAR, new Car());
            vehicleDictionary.Add(VehicleType.BOAT, new Boat());
        }
        public async Task<IEnumerable<VehicleInfo>> GetVehicleProperties(VehicleType vehicleType)
        {
            IEnumerable<VehicleInfo> vehicleProperties = null;
            try
            {
                vehicleProperties= await Task.Run(() => GetProperties(vehicleType));
            }
            catch (Exception)
            {
                //shout/catch/throw/log
            }
            return vehicleProperties;

        }
        IEnumerable<VehicleInfo> GetProperties(VehicleType vehicleType)
        {
            var vehicle = vehicleDictionary[vehicleType];

            foreach (var prop in vehicle.GetType().GetProperties())
            {
                yield return new VehicleInfo()
                {
                    Value = string.Empty,
                    Name = prop.Name,
                    Datatype = prop.PropertyType.Name,
                    Order = prop.GetCustomAttributes(typeof(DisplayAttribute), true).Any() ? ((DisplayAttribute)(prop.GetCustomAttributes(typeof(DisplayAttribute), true)[0])).Order : 0,
                    Required = prop.GetCustomAttributes(typeof(RequiredAttribute), true).Any() ? true : false,
                    Regex = prop.GetCustomAttributes(typeof(RegularExpressionAttribute), true).Any() ? ((RegularExpressionAttribute)(prop.GetCustomAttributes(typeof(RegularExpressionAttribute), true)[0])).Pattern : ""
                };
            }
        }

        public Vehicle GetVehicleType(VehicleType vehicleType)
        {
            var vehicle = vehicleDictionary[vehicleType];
            return vehicle;

        }
    }
}
