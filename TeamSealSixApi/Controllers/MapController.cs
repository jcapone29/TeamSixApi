using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Script.Serialization;
using DataAccess.Repositories;

namespace TeamSealSixApi.Controllers
{
    [RoutePrefix("api/Map")]
    public class MapController : ApiController
    {
        private readonly MapRepository _mapRepository;
        public MapController()
        {
            _mapRepository = new MapRepository(ConfigurationManager.ConnectionStrings["TheDump"].ConnectionString);
        }
        [Route("coordinates")]
        public string Get()
        {
            var mapCoordinates = _mapRepository.GetMapModels();
            return new JavaScriptSerializer().Serialize(mapCoordinates);
        }

        [Route("light")]
        [HttpGet]
        public string GetLights()
        {
            var mapCoordinates = _mapRepository.GetLightModels();
            return new JavaScriptSerializer().Serialize(mapCoordinates);
        }


    }
}