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
        }
    }
}
