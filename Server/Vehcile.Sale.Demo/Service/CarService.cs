using Microsoft.EntityFrameworkCore;
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
        Task<string> AddVehicle(Vehicle vehicle);
        Task<string> UpdateVehicle(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> ViewAllVehicle();
        Task<Vehicle> GetSpecificVehicle(Vehicle vehicle);


    }
    public interface ICarService : IService { }
    public class CarService : ICarService
    {
        DataContext _context;
        public CarService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddVehicle(Vehicle vehicle)
        {
            try
            {
                Car car = vehicle as Car;
                _context.Add(car);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return e.Message;
            }
        }

        public async Task<Vehicle> GetSpecificVehicle(Vehicle vehicle)
        {
            try
            {
                var targetItem = await _context.Cars.FindAsync(vehicle.Id);
                if (targetItem == null)
                    return new Car();

                return targetItem;
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return null;
            }
        }

        public async Task<string> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                var targetItem = _context.Cars.Find(vehicle.Id);
                Car car = vehicle as Car;
                if (targetItem == null)
                    return "Item not found";

                _context.Entry(targetItem).CurrentValues.SetValues(car);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return e.Message;
            }
        }

        public async Task<IEnumerable<Vehicle>> ViewAllVehicle()
        {
            try
            {
                return _context.Cars;
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }
        }

    }
}
