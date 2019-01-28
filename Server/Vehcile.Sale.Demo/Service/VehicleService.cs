using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IVehicleService
    {
        IEnumerable<string> GetVehicleTypes();
        Task<IEnumerable<VehicleInfo>> GetVehicleProperties(string vehicleType);
        Task<string> AddVehicle(JObject vehicle);
        Task<string> UpdateVehicle(JObject vehicle);
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetSpecificVehicle(string type, int Id);
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

        public async Task<string> AddVehicle(JObject vehicleObj)
        {

            try
            {
                var vehicle = _vehicleConverter.Convert(vehicleObj);
                if (vehicle != null)
                    return await _dbService.AddVehicle(vehicle);
                else return "Vehicle type not found";
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return e.Message;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            try
            {
                return await _dbService.GetAllVehicles();
            }
            catch (Exception)
            {
                //shout/catch/throw/log
                return null;
            }
        }

        public async Task<Vehicle> GetSpecificVehicle(string type, int Id)
        {
            VehicleType vehicletype;
            try
            {
                if (Enum.TryParse(type, true, out vehicletype))
                    return await _dbService.GetSpecificVehicle(vehicletype, Id);
                else return null;
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }
        }

        public async Task<IEnumerable<VehicleInfo>> GetVehicleProperties(string vehicleType)
        {
            VehicleType enumName;
            try
            {
                if (Enum.TryParse(vehicleType, true, out enumName))
                {
                    var vTypes = await _vehicleStrategyContext.GetVehicleProperties(enumName);
                    return vTypes.OrderBy(a => a.Order);
                }
                else return null;
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }

        }

        public IEnumerable<string> GetVehicleTypes()
        {
            try
            {
                return Enum.GetNames(typeof(VehicleType));
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }
        }

        public async Task<string> UpdateVehicle(JObject vehicleObj)
        {
            Vehicle vehicle;
            try
            {
                vehicle = _vehicleConverter.Convert(vehicleObj);
                if (vehicle != null)
                    return await _dbService.UpdateVehicle(vehicle);
                else return "Vehicle type not found";
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return e.Message;
            }
        }
    }
}
