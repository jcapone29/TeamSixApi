using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using DataAccess.Entities;
using System.Threading.Tasks;

namespace TeamSealSixApi.Controllers
{
    [RoutePrefix("api/Car")]
    public class CarController : ApiController
    {

        private readonly CarService _carService;

        public CarController()
        {
            _carService = new CarService();
        }

        [Route("sensor/{id}")]
        public async Task<IHttpActionResult> GetSensorsByIds(string id)
        {
            return Ok(await _carService.GetSensorsById(id));
        }

        [HttpPost]
        [Route("sensor")]
        public async Task<IHttpActionResult> PostSensorsById(Sensor payload)
        {
            return Ok(await _carService.PostSensorsById(payload));
        }
    }
}
