using HackbotFB.Gestiones;
using HackbotFB.Models.FbBotData;
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
            Task.Factory.StartNew(() =>
            {
                foreach (var entry in data.entry)
                {
                    foreach (var message in entry.messaging)
                    {
                        if (string.IsNullOrWhiteSpace(message?.message?.text))
                            continue;

                        var msg = "You said: " + message.message.text;
                        var json = $@" {{recipient: {{  id: {message.sender.id}}},message: {{text: ""{msg + message.sender.id}"" }}}}";
                        Acciones.PostRaw("https://graph.facebook.com/v3.0/me/messages?access_token=EAAF3NCI0yUQBAMx3ZCirrlZCuYDNoLaD092M4ncaZAYmu03C5Rku5tCPFLZBqmh2LEjD03u6fZAw3NtLhJLO7WEiJuHZCOFSmbEiZAR1DsiZAZBEWdQ9qizdz0HDJCQeH1wZBhG4HVxKddyTtyKxaMBSZCnoXeSCJY4AARmf6C1wmyIOAZDZD", json);
                        Task.Factory.StartNew(() =>
                        {
                            servicios.LlamarPost<dynamic>("http://localhost:61627/api/Message/Mensaje", message);
                        });
                    }
                }
            });

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}