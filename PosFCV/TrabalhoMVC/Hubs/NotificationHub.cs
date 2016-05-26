using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TrabalhoMVC.Hubs
{
    public class NotificationHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("Olá");
        }
    }
}