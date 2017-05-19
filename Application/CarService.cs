using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataAccess.Entities;
using System.Net;

namespace Application
{
    public class CarService
    {
        private readonly SensorRepository _sensorRepository;
        public CarService()
        {
            _sensorRepository = new SensorRepository();
        }


        public async Task<IEnumerable<Sensor>> GetSensorsById(string sensorId)
        {
            return _sensorRepository.GetSensorsById(sensorId);
        }
        public async Task<HttpStatusCode> PostSensorsById(Sensor sensor)
        {
            try
            {
                _sensorRepository.Save(sensor);               
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }
    }
}

    

