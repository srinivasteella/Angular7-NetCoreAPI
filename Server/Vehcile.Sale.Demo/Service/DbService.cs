using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IDbService
    {
        Task<string> AddVehicle(Vehicle vehicle);

        Task<string> UpdateVehicle(Vehicle vehicle);

        Task<IEnumerable<Vehicle>> GetAllVehicles();

        Task<Vehicle> GetSpecificVehicle(VehicleType vehicletype, int Id);

    }
    public class DbService : IDbService
    {
        ICarService _carService;
        IBoatService _boatService;
        Dictionary<VehicleType, IService> dict = new Dictionary<VehicleType, IService>();
        public DbService(ICarService carService, IBoatService boatService)
        {
            _carService = carService;
            _boatService = boatService;
            dict.Add(VehicleType.BOAT, _boatService);
            dict.Add(VehicleType.CAR, _carService);
        }

        public async Task<string> AddVehicle(Vehicle vehicle)
        {
            try
            {
                return await dict[vehicle.VehicleType].AddVehicle(vehicle);
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
                var vehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();

                return await GetAll(vehicleTypes);
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }
        }

        async Task<IEnumerable<Vehicle>> GetAll(IEnumerable<VehicleType> vehicleTypes)
        {
            try
            {
                var vehicles = new List<Vehicle>();

                foreach (var vehicleType in vehicleTypes)
                {

                    vehicles.AddRange(await dict[vehicleType].ViewAllVehicle());
                }
                return vehicles;
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }
        }

        public async Task<string> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                return await dict[vehicle.VehicleType].UpdateVehicle(vehicle);
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return e.Message;
            }
        }

        public async Task<Vehicle> GetSpecificVehicle(VehicleType type, int Id)
        {
            try
            {
                return await dict[type].GetSpecificVehicle(Id);
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }
        }
    }
}
