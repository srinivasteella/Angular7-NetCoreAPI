using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSale.Demo.Datastore;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IVehicleFactoryService
    {
        IService getVehicleInstance(string vehicleType);
    }

    public class VehicleFactoryService : IVehicleFactoryService
    {
        DataContext dataContext;
        public IService getVehicleInstance(string vehicleType)
        {
            var options = new DbContextOptionsBuilder<DataContext>().EnableSensitiveDataLogging(true).UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            dataContext = new DataContext(options);
            var types = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(s => s.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IService)))
              .Where(u => !u.IsAbstract));

            foreach (var type in types)
            {
                if (type.Name.ToString().ToLowerInvariant().Equals(vehicleType + "service"))
                {
                    var subType = Activator.CreateInstance(type, dataContext) as IService;
                    return subType;
                }
            }
            return null;
        }
    }
}
