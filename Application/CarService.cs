using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataAccess.Entities;

namespace Application
{
    public class CarService
    {
        private readonly CarRepository _carRepository;
        public CarService()
        {
            _carRepository = new CarRepository();
        }


        public async Task<CarTest> GetTest()
        {
            return new CarTest
            {
                Ids = 1,
                Message = "Test Message"
            };
        }
        public async Task PostTest(CarTest carTest)
        {

        }

        public async Task HandleCarSensorMessage(HubEntity<Sensor> message)
        {

            await _carRepository.PostSensorMessage(message.Entity.First());
        }
    }
}

