using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class HubEntity<T> : IHub<T>
    {
        public IEnumerable<T> Entity { get; set; }
        public string Group { get; set; }
    }
}
