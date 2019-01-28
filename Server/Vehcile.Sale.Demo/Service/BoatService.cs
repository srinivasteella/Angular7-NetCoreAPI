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
    public interface IBoatService : IService { }
    public class BoatService : IBoatService
    {
        DataContext _context;
        public BoatService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddVehicle(Vehicle vehicle)
        {
            try
            {
                Boat newboat = vehicle as Boat;
                _context.Add(newboat);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return e.Message;
            }
        }

        public async Task<string> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                Boat editBoat = vehicle as Boat;
                var targetItem = _context.Boats.Find(editBoat.Id);
                if (targetItem == null)
                    return "Item not found";

                _context.Entry(targetItem).CurrentValues.SetValues(editBoat);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                //shout/catch/throw/log
                return e.Message;
            }
        }

        public async Task<Vehicle> GetSpecificVehicle(int Id)
        {
            Vehicle targetVehicle = null;
            try
            {
                targetVehicle = await _context.Boats.FindAsync(Id);
                if (targetVehicle == null)
                    return new Boat();
            }
            catch (Exception)
            {
                //shout/catch/throw/log
            }
            return targetVehicle;
        }

        public async Task<IEnumerable<Vehicle>> ViewAllVehicle()
        {
            try
            {
                return await Task.Run(() => _context.Boats);
            }
            catch
            {
                return null;
            }
        }

    }
}
