using System;
using System.Configuration;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Integration.Tests
{
    [TestClass]
    public class SensorRepositoryFixture
    {
        private readonly string _connectionString;
        private readonly SensorRepository _sensorRepository;
        public SensorRepositoryFixture()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TheDump"].ConnectionString;
            _sensorRepository = new SensorRepository();

        }
        [TestMethod]
        public void GivenAnSensorIdWeShouldGetANotNullSensorModel()
        {
            var sensor = _sensorRepository.GetSensorsById("Sensor1").SingleOrDefault();
            Assert.IsNotNull(sensor);
        }

        [TestMethod]
        public void GivenAnValidSensorModelWhenSavingWeShouldNotHaveException()
        {
            Exception expectedException = null;
            try
            {
                var sensor = new Sensor
                {
                    SensorID = "Sensor1",
                    TimeStamp = DateTime.UtcNow,
                    Message = "Test insert statement"

                };

                _sensorRepository.Save(sensor);
            }
            catch (Exception exception)
            {
                expectedException = exception;
            }
            Assert.IsNull(expectedException);
        }
    }
}
