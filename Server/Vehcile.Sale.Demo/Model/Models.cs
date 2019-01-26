using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSale.Demo.Model
{
    public enum VehicleType
    {
        CAR = 0,
        BOAT = 1
    }
    public abstract class Vehicle
    {
        public int Id { get; set; }
        [Display(Order = 1)]
        [Required]
        public string Model { get; set; }

        [Display(Order = 2)]
        [Required]
        public string Make { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]

        public abstract VehicleType VehicleType { get; }
    }
    public class VehicleInfo
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Datatype { get; set; }
        public string Regex { get; set; }
        public bool Required { get; set; }

        public dynamic Value { get; set; }


    }
    public class Car : Vehicle
    {
        [Required]
        [RegularExpression(@"^[1-9]{1}$")]
        [Display(Order = 3)]
        public int Doors { get; set; }

        [Required]
        [Display(Order = 4)]
        public string Engine { get; set; }

        [Required]
        [RegularExpression(@"^[4-9]{1}$")]
        [Display(Order = 5)]
        public int Wheels { get; set; }

        [Required]
        [Display(Order = 6)]
        public string BodyType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public override VehicleType VehicleType => VehicleType.CAR;
    }
    public class Boat : Vehicle
    {
        [Required]
        [RegularExpression(@"^[1-9]{1,2}$")]
        [Display(Order = 7)]
        public int Storey { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]{1,5}$")]
        [Display(Order = 8)]
        public int Seats { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]

        public override VehicleType VehicleType => VehicleType.BOAT;
    }
}
