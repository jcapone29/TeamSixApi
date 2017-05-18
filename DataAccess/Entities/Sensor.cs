using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Sensor
    {
        string SesnorId { get; set; }

        DateTime TimeStamp = DateTime.UtcNow;
        string Message { get; set; }

    }
}
