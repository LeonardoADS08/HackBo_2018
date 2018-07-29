using HackbotFB.Models.FbBotData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HackbotFB.Gestiones
{
    public class RequestService
    {
        private static readonly HttpClient ClienteHttp;

        static RequestService()
        {
            ClienteHttp = new HttpClient();
        }

        public T LlamarPost<T>(string Url, object body)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "POST";
            string stringrespuesta;
            T objeto;
            using (var requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(JsonConvert.SerializeObject(body));
            }

            var response = (HttpWebResponse)request.GetResponse();
            if (response == null)
            {
                throw new InvalidOperationException("Respuesta nula");
            }
            using (var respuesta = new StreamReader(response.GetResponseStream()))
            {
                stringrespuesta = respuesta.ReadToEnd();
            }

            objeto = JsonConvert.DeserializeObject<T>(stringrespuesta);
            return objeto;
        }
    }
}