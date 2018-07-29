using HackbotFB.Gestiones;
using HackbotFB.Models.Acciones;
using HackbotFB.Models.FbBotData;
using HackbotFB.Models.Hub;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HackbotFB.Controllers
{
    public class FbConnectController : Controller
    {
        public ActionResult Receive()
        {
            var query = Request.QueryString;

            System.Diagnostics.Debug.WriteLine(Request.RawUrl);

            if (query["hub.mode"] == "subscribe" &&
                query["hub.verify_token"] == "tacotaco")
            {
                //string type = Request.QueryString["type"];
                var retVal = query["hub.challenge"];
                return Json(int.Parse(retVal), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [ActionName("Receive")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReceivePost(BotRequest data)
        {
            RequestService servicios = new RequestService();
            MensajesTexto nuevo = new Models.Acciones.MensajesTexto();
            Task.Factory.StartNew(() =>
            {
                foreach (var entry in data.entry)
                {
                    foreach (var message in entry.messaging)
                    {
                        if (string.IsNullOrWhiteSpace(message?.message?.text))
                            continue;
                        //var msg = "You said: " + message.message.text;
                        //var json = $@" {{recipient: {{  id: {message.sender.id}}},message: {{text: ""{msg + message.sender.id}"" }}}}";
                        //Acciones.PostRaw("https://graph.facebook.com/v3.0/me/messages?access_token=EAAF3NCI0yUQBAMx3ZCirrlZCuYDNoLaD092M4ncaZAYmu03C5Rku5tCPFLZBqmh2LEjD03u6fZAw3NtLhJLO7WEiJuHZCOFSmbEiZAR1DsiZAZBEWdQ9qizdz0HDJCQeH1wZBhG4HVxKddyTtyKxaMBSZCnoXeSCJY4AARmf6C1wmyIOAZDZD", json);

                        if (!ManejoDeInfo.Conectado(message.sender.id))
                        {
                            var respuesta=DialogFlow.RequestManager.Query(new DialogFlow.Models.Request(new List<string>(), message.message.text,message.sender.id));
                            nuevo.message.text = respuesta.result.fulfillment.speech;
                            nuevo.recipient.id = respuesta.sessionId;
                            if (!respuesta.result.actionIncomplete)
                            {
                                ManejoDeInfo.VerificarRuta(message.sender.id);
                                ManejoDeInfo.RegistrarSolicitud(respuesta.result.parameters, message.sender.id);
                            }
                            Acciones.EnviarMensajeTextoAsync(nuevo);
                        }
                        else
                        {
                            if (message.message.text.ToUpper().Contains("DESCONECTAR"))
                            {
                                ManejoDeInfo.Desconectar(message.sender.id);
                            }
                            Task.Factory.StartNew(() =>
                            {
                                //servicios.LlamarPost<dynamic>("http://localhost:61627/api/Message/Mensaje", message);
                                var hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                                string ruta = ManejoDeInfo.ObtenerRuta(message.sender.id);
                                UsuarioConectado jarcodeo = ChatHub.lista.FirstOrDefault(x => x.id == ruta);
                                FbUser usuario = Acciones.recuperarContacto(message.sender.id);
                                hubContext.Clients.Client(jarcodeo.connectionId).recibirMensaje(message.message.text, usuario.first_name + " " + usuario.last_name, message.sender.id);

                            });
                        }


                    }
                }
            });

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}