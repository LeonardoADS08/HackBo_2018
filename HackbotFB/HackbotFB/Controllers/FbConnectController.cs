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
            Task.Factory.StartNew(() =>
            {
                foreach (var entry in data.entry)
                {
                    foreach (var message in entry.messaging)
                    {
                        if (string.IsNullOrWhiteSpace(message?.message?.text))
                            continue;

                        var msg = "You said: " + message.message.text;
                        var json = $@" {{recipient: {{  id: {message.sender.id}}},message: {{text: ""{msg}"" }}}}";
                        Acciones.PostRaw("https://graph.facebook.com/v3.0/me/messages?access_token=EAAF3NCI0yUQBAK6gZCR0tZAyyMdNXMO9jhYD240FX80vZAJpLjYbZBDpg7SZBw4LgZBuKZA95pQdJZCXLvAU25l37P3a3CvlTiwAhsY3uPQbSA3c5IxiPPk10urGHWuLLZBGbcl7ggJNx7CNh8mFRomK0Wed1hTO8tjzgPoHyYdXi0QZDZD", json);
                        //Task.Factory.StartNew(() =>
                        //{
                        //    RequestService.MakeRequest<dynamic>("http://localhost:61627/api/Message/Mensaje", "POST", message);
                        //});
                    }
                }
            });

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}