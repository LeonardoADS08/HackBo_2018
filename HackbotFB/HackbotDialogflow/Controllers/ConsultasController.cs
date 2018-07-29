using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HackbotDialogflow.Controllers
{
    public class ConsultasController : ApiController
    {
        public JObject EnviarMensaje(JObject data)
        {
            return JObject.FromObject(new { objeto = "" });
        }
    }
}
