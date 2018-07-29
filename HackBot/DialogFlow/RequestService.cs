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

namespace DialogFlow
{
    public class RequestService
    {
        public T LlamarPost<T>(string Url, object body)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer d2dc33dff9ab4301a1c6d215086be3e8");
            request.Method = "POST";
            using (var requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(body);
            }
            string stringrespuesta;
            T objeto;

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

        public string PostRaw(string url, string data)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer d2dc33dff9ab4301a1c6d215086be3e8");
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
    }
}