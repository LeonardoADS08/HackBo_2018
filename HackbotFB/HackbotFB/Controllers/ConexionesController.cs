using HackbotFB.Gestiones;
using HackbotFB.Models.Acciones;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HackbotFB.Controllers
{
    public class ConexionesController : ApiController
    {
        public async System.Threading.Tasks.Task<JObject> EnviarMensajesAsync(JObject data)
        {
            MensajesTexto nuevo = data.ToObject<MensajesTexto>();
            await Acciones.EnviarMensajeTextoAsync(nuevo);
            return JObject.FromObject(nuevo);
        }
    }
}
