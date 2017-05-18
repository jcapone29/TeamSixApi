using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    interface IHub<T>
    {
        IEnumerable<T> Entity { get; set; }
        string Group { get; set; }

    }
}
