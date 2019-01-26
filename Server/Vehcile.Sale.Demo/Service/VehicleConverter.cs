using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSale.Demo.Model;

namespace VehicleSale.Demo.Service
{
    public interface IVehicleConverter
    {
        Vehicle Convert(JObject vehicleObj);
    }
    public class VehicleConverter : IVehicleConverter
    {
        Dictionary<VehicleType, Func<JObject, Vehicle>> dict = new Dictionary<VehicleType, Func<JObject, Vehicle>>();
        public VehicleConverter()
        {
            dict.Add(VehicleType.CAR, GetCar);
            dict.Add(VehicleType.BOAT, GetBoat);
        }
        public Vehicle Convert(JObject vehicleObj)
        {
            var vehicleType = vehicleObj.GetValue("VehicleType");//.ToObject<int>();

            VehicleType enumName = (VehicleType)Enum.Parse(typeof(VehicleType), vehicleType.ToObject<string>(), true);

            return dict[enumName].Invoke(vehicleObj);
        }

        Car GetCar(JObject vehicleObj)
        {
            return JsonConvert.DeserializeObject<Car>(vehicleObj.ToString());
        }
        Boat GetBoat(JObject vehicleObj)
        {
            return JsonConvert.DeserializeObject<Boat>(vehicleObj.ToString());
        }
    }
}
