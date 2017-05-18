using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNet.SignalR;
using Application;

namespace Hub
{
   public class BaseClientProxy: Microsoft.AspNet.SignalR.Hub, IBaseClientProxy
    {

        private readonly IHubContext _context;

        public BaseClientProxy()
        {
            _context = GlobalHost.ConnectionManager.GetHubContext<BaseClientProxy>();
        }

        public async Task Broadcast<T>(HubEntity<T> entity)
        {
            await _context.Clients.Group(entity.Group).broadcast(entity);
        }

        public async Task Recieve<T>(HubEntity<T> entity)
        {
            throw new NotImplementedException();
        }

        public async Task Subscribe(string group)
        {
            await _context.Groups.Add(Context.ConnectionId, group);
        }

        public async Task UnSubscribe(string group)
        {
            await _context.Groups.Remove(Context.ConnectionId, group);
        }

    }
}   