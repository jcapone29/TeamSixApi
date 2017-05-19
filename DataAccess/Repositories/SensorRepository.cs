using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Entities;
using Newtonsoft.Json;

namespace DataAccess.Repositories
{
    public class SensorRepository
    {
        private readonly string _connectionString;

        public SensorRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TheDump"].ConnectionString;
        }

        public IEnumerable<Sensor> GetSensorsById(string SensorID)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"Select * From TheDump WHERE SensorID = @SensorID";
                return db.Query<Sensor>(sqlQuery, new { SensorID }).ToList();

            };
        }


        public void Save(Sensor sensor)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))

            {

                string sqlQuery = @"INSERT INTO TheDump([TimeStamp], [SensorID],[Message]) VALUES 
                                   (@TimeStamp,@SensorID,@Message)";

                db.Execute(sqlQuery, new { sensor.TimeStamp, sensor.SensorID, sensor.Message });



            }
            if (sensor.SensorID == "photoresistor")
            {
                var result = JsonConvert.DeserializeObject<PhotoSensor>(sensor.Message);
                if (result.reading < 100)
                {
                    SaveLightCoordinates(sensor);
                }
            }
            if (sensor.SensorID == "car-stop")
            {
                SaveLRoute(sensor);
            }
            if (sensor.SensorID == "sonar-left")
            {
                SaveRouteLeft(sensor);
            }
            if (sensor.SensorID == "sonar-right")
            {
                SaveRouteRight(sensor);
            }
            
        }

        private void SaveLightCoordinates(Sensor sensor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TimeStamp",sensor.TimeStamp);
                parameters.Add("@SensorID",sensor.SensorID);
                parameters.Add("@Message",sensor.Message);

                connection.Query<Sensor>("pr_lightCordinates", parameters,
                    commandType: CommandType.StoredProcedure);
                
            }
        }
        private void SaveLRoute(Sensor sensor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@time", sensor.TimeStamp);
                
                

                connection.Query<Sensor>("pr_insert_route", parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        private void SaveRouteLeft(Sensor sensor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TimeStamp", sensor.TimeStamp);
                parameters.Add("@SensorID", sensor.SensorID);
                parameters.Add("@Message", sensor.Message);

                connection.Query<Sensor>("pr_insert_object_left", parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }
        private void SaveRouteRight(Sensor sensor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TimeStamp", sensor.TimeStamp);
                parameters.Add("@SensorID", sensor.SensorID);
                parameters.Add("@Message", sensor.Message);

                connection.Query<Sensor>("pr_insert_object_right", parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }
    }
}
