using DialogFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogFlow
{
    public static class RequestManager
    {
        public static Response Query(Request req)
        {
            string url = @"https://api.dialogflow.com/v1/query?v=28ad5";
            string json = req.ToJson();
            var request = new RequestService();

            var respuesta = request.LlamarPost<DialogFlow.Models.RawResponse>(url, json);
            return new Response(respuesta);
        }
    }
}
