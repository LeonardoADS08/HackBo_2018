using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using Microsoft.AspNet.SignalR;

namespace HackbotFB
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChatHub:Hub
    {
        public void Send()
        {
            var a = Context.ConnectionId;

            Console.Beep();
        }

    }
}