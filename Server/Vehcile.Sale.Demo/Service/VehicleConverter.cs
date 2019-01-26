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
            JToken vehicleType;
            if (vehicleObj.TryGetValue("VehicleType", out vehicleType))//.ToObject<int>();
            {
                VehicleType enumName;

                if (Enum.TryParse(vehicleType.ToString(), true, out enumName))

                    return dict[enumName].Invoke(vehicleObj);

                else return null;
            }
            else return null;
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
