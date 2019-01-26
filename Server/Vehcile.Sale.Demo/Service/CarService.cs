using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSale.Demo.Datastore;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IService
    {
        string AddVehicle(Vehicle vehicle);
        string UpdateVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> ViewAllVehicle();
        Vehicle GetSpecificVehicle(Vehicle vehicle);


    }
    public interface ICarService : IService { }
    public class CarService : ICarService
    {
        DataContext _context;
        public CarService(DataContext context)
        {
            _context = context;
        }

        public string AddVehicle(Vehicle vehicle)
        {
            Car car = vehicle as Car;
            _context.Add(car);
            _context.SaveChanges();
            return "Success";
        }

        public Vehicle GetSpecificVehicle(Vehicle vehicle)
        {
            var targetItem = _context.Cars.Find(vehicle.Id);
            if (targetItem == null)
                return new Car();

            return targetItem;
        }

        public string UpdateVehicle(Vehicle vehicle)
        {
            var targetItem = _context.Cars.Find(vehicle.Id);
            Car car = vehicle as Car;
            if (targetItem == null)
                return "Item not found";

            _context.Entry(targetItem).CurrentValues.SetValues(car);
            _context.SaveChanges();
            return "Success";
        }

        public IEnumerable<Vehicle> ViewAllVehicle()
        {
            return _context.Cars;
        }

    }
}
