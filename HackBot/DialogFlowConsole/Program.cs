using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogFlow;
using DialogFlow.Models;

namespace DialogFlowConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://api.dialogflow.com/v1/query?v=28ad5";
            string json = new Request(new List<string>() { "PreguntarCredito" }, "Quiero un credito para vivienda.").ToJson();
            Debug.WriteLine(json);
            var request = new RequestService();

            var respuesta = request.LlamarPost<DialogFlow.Models.RawResponse>(url, json);
            Debug.Write(respuesta);
        }
    }
}
