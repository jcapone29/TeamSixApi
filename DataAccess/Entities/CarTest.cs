using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
  public class CarTest : EntityBase
    {
        public int Ids { get; set; }
        public DateTime TimeStamp = DateTime.Now;
        public string Message { get; set; }
    }
}
