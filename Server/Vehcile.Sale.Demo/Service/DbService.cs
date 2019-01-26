using System;
using System.Collections.Generic;
using System.Linq;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IDbService
    {
        string AddVehicle(Vehicle vehicle);

        string UpdateVehicle(Vehicle vehicle);

        IEnumerable<Vehicle> GetAllVehicles();

        Vehicle GetSpecificVehicle(Vehicle vehicle);

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

        public string AddVehicle(Vehicle vehicle)
        {
            return dict[vehicle.VehicleType].AddVehicle(vehicle);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {

            var vehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();

            return GetAll(vehicleTypes);
        }

        IEnumerable<Vehicle> GetAll(IEnumerable<VehicleType> vehicleTypes)
        {
            var vehicles = new List<Vehicle>();

            foreach (var vehicleType in vehicleTypes)
            {
                vehicles.AddRange(dict[vehicleType].ViewAllVehicle());
            }
            return vehicles;
        }

        public string UpdateVehicle(Vehicle vehicle)
        {
            return dict[vehicle.VehicleType].UpdateVehicle(vehicle);
        }

        public Vehicle GetSpecificVehicle(Vehicle vehicle)
        {
            return dict[vehicle.VehicleType].GetSpecificVehicle(vehicle);
        }
    }
}
