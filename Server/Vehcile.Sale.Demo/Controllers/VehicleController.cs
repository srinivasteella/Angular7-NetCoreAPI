using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VehicleSale.Demo.Model;
using VehicleSale.Demo.Service;

namespace VehicleSale.Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        /// <summary>
        /// Retrieve all the Vehicle types.
        /// </summary>
        [HttpGet("types")]
        [ProducesResponseType(200, Type = typeof(List<string>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var vehicleTypes = _vehicleService.GetVehicleTypes();
                if (vehicleTypes == null) return NotFound();
                return Ok(vehicleTypes);
            }
            catch (Exception)
            {
                return BadRequest();//shout/catch/throw/log
            }
        }
        /// <summary>
        /// Retrieves all properties of the supplied vehicle type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("{type}")]
        [ProducesResponseType(200, Type = typeof(List<string>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<VehicleInfo>> GetVehicleProperties(string type)

        {
            try
            {
                var vehicleProperties = _vehicleService.GetVehicleProperties(type);
                if (vehicleProperties == null) return NotFound();
                return Ok(vehicleProperties);
            }
            catch (Exception)
            {
                return BadRequest();//shout/catch/throw/log
            }
        }
        /// <summary>
        /// Retrieves all the vehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200, Type = typeof(List<Vehicle>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<List<Vehicle>> GetAllVehicles()
        {
            try
            {
                var vehicles = _vehicleService.GetAllVehicles();
                if (vehicles == null) return NotFound();
                return Ok(vehicles);
            }
            catch (Exception)
            {
                return BadRequest();//shout/catch/throw/log
            }
        }
        /// <summary>
        /// Add a vehicle with detail
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public ActionResult<string> AddVehicle([FromBody]JObject vehicle)
        {
            if (vehicle == null || !ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var vehicleAddmessage = _vehicleService.AddVehicle(vehicle);
                return Ok(vehicleAddmessage);
            }
            catch (Exception)
            {
                return BadRequest();//shout/catch/throw/log
            }
        }

        /// <summary>
        /// Get a vehicle with details
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public ActionResult<Vehicle> GetSpecificVehicle([FromBody]JObject vehicle)
        {
            if (vehicle == null || !ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var vehicleAddmessage = _vehicleService.GetSpecificVehicle(vehicle);
                return Ok(vehicleAddmessage);
            }
            catch (Exception)
            {
                return BadRequest();//shout/catch/throw/log
            }
        }

        /// <summary>
        /// Update the vehicle detail
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public ActionResult<string> UpdateVehicle([FromBody]JObject vehicle)
        {
            if (vehicle == null || !ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var updatedMessage = _vehicleService.UpdateVehicle(vehicle);
                return Ok(updatedMessage);
            }
            catch (Exception)
            {
                return BadRequest();//shout/catch/throw/log
            }
        }
    }
}