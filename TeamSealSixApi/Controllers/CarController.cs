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

        [Route("test")]
        public async Task<IHttpActionResult> GetTest()
        {
            return Ok(await _carService.GetTest());

        }

        //[HttpPost]
        //[Route("test/{id}/{message}")]
        //public async Task<IHttpActionResult> PostTest(CarTest cartest)
        //{
        //    return Ok(await _carService.PostTest(cartest));

        //}
    }
}
