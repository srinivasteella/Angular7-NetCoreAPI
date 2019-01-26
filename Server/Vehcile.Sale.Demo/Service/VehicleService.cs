using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IVehicleService
    {
        IEnumerable<string> GetVehicleTypes();
        IEnumerable<VehicleInfo> GetVehicleProperties(string vehicleType);
        string AddVehicle(JObject vehicle);
        string UpdateVehicle(JObject vehicle);
        IEnumerable<Vehicle> GetAllVehicles();
        Vehicle GetSpecificVehicle(JObject vehicle);


    }
    public class VehicleService : IVehicleService
    {
        IVehicleStrategyContext _vehicleStrategyContext;
        IDbService _dbService;
        IVehicleConverter _vehicleConverter;
        public VehicleService(IVehicleStrategyContext vehicleStrategyContext, IDbService dbService, IVehicleConverter vehicleConverter)
        {
            _vehicleStrategyContext = vehicleStrategyContext;
            _dbService = dbService;
            _vehicleConverter = vehicleConverter;
        }

        public string AddVehicle(JObject vehicleObj)
        {

            try
            {
                var vehicle = _vehicleConverter.Convert(vehicleObj);

                return _dbService.AddVehicle(vehicle);
            }
            catch (Exception e)
            {

                return e.Message; // throw//log//shout
            }
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            try
            {
                return _dbService.GetAllVehicles();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Vehicle GetSpecificVehicle(JObject vehicleObj)
        {
            var vehicle = _vehicleConverter.Convert(vehicleObj);

            return _dbService.GetSpecificVehicle(vehicle);
        }

        public IEnumerable<VehicleInfo> GetVehicleProperties(string vehicleType)
        {
            VehicleType enumName = (VehicleType)Enum.Parse(typeof(VehicleType), vehicleType, true);
            return _vehicleStrategyContext.GetVehicleProperties(enumName).OrderBy(a => a.Order);
        }

        public IEnumerable<string> GetVehicleTypes()
        {
            return Enum.GetNames(typeof(VehicleType));
        }

        public string UpdateVehicle(JObject vehicleObj)
        {
            var vehicle = _vehicleConverter.Convert(vehicleObj);

            return _dbService.UpdateVehicle(vehicle);
        }
    }
}
