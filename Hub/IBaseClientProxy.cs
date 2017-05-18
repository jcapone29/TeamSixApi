using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Hub
{
    interface IBaseClientProxy
    {
        Task Broadcast<T>(HubEntity<T> entity);
        Task Recieve<T>(HubEntity<T> entity);
        Task Subscribe(string group);
        Task UnSubscribe(string group);
    }
}
