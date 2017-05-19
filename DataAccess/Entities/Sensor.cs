using System;


namespace DataAccess.Entities
{
   public class Sensor
    {
        public string SensorID { get; set; }
        public DateTime TimeStamp = DateTime.Now;
        public string Message { get; set; }

    }
}
