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

        public string AddVehicle(Vehicle vehicle)
        {
            Boat newboat = vehicle as Boat;
            _context.Add(newboat);
            _context.SaveChanges();
            return "Success";
        }

        public string UpdateVehicle(Vehicle vehicle)
        {
            Boat editBoat = vehicle as Boat;
            var targetItem = _context.Boats.Find(editBoat.Id);
            if (targetItem == null)
                return "Item not found";

            _context.Entry(targetItem).CurrentValues.SetValues(editBoat);
            _context.SaveChanges();
            return "Success";
        }

        public Vehicle GetSpecificVehicle(Vehicle vehicle)
        {
            var targetItem = _context.Boats.Find(vehicle.Id);
            if (targetItem == null)
                return new Boat();

            return targetItem;
        }

        public IEnumerable<Vehicle> ViewAllVehicle()
        {
            return _context.Boats;
        }
    }
}
