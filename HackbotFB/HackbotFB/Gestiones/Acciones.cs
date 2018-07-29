using HackbotFB.Models.Acciones;
using HackbotFB.Models.FbBotData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace HackbotFB.Gestiones
{
    public static class Acciones
    {
        public static string PostRaw(string url, string data)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(data);
            }

            var response = (HttpWebResponse)request.GetResponse();
            if (response == null)
                throw new InvalidOperationException("GetResponse returns null");

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }

        public static async System.Threading.Tasks.Task EnviarMensajeTextoAsync(MensajesTexto nuevo)
        {
            RequestService servicio = new RequestService();
            servicio.LlamarPost<object>("https://graph.facebook.com/v3.0/me/messages?access_token=EAAF3NCI0yUQBAMx3ZCirrlZCuYDNoLaD092M4ncaZAYmu03C5Rku5tCPFLZBqmh2LEjD03u6fZAw3NtLhJLO7WEiJuHZCOFSmbEiZAR1DsiZAZBEWdQ9qizdz0HDJCQeH1wZBhG4HVxKddyTtyKxaMBSZCnoXeSCJY4AARmf6C1wmyIOAZDZD", nuevo);
        }

        public static FbUser recuperarContacto(string fbUserId) {
            RequestService servicio = new RequestService();
            FbUser usuario = servicio.LlamarGet<FbUser>("https://graph.facebook.com/v3.0/" + fbUserId + "?fields=id,first_name,last_name,profile_pic,gender,locale,timezone&access_token=EAAF3NCI0yUQBAMx3ZCirrlZCuYDNoLaD092M4ncaZAYmu03C5Rku5tCPFLZBqmh2LEjD03u6fZAw3NtLhJLO7WEiJuHZCOFSmbEiZAR1DsiZAZBEWdQ9qizdz0HDJCQeH1wZBhG4HVxKddyTtyKxaMBSZCnoXeSCJY4AARmf6C1wmyIOAZDZD");
            return usuario;
        }
    }
}