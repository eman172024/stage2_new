using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MMSystem.Hubs
{
    public class Testhub : Hub
    {
        public async Task sendmassage(bool state1, string massage)
        //  public async Task sendmassage( string massage)
        {

            await Clients.All.SendAsync("resivemassage", state1, massage);
            // await Clients.All.SendAsync("resivemassage", massage);
        }
    }
}
