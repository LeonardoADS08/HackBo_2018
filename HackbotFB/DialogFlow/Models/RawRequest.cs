using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogFlow.Models
{
    public class RawRequest
    {
        public List<string> contexts { get; set; }
        public string lang { get; set; }
        public string query { get; set; }
        public string sessionId { get; set; }
        public string timezone { get; set; }

        public RawRequest() { }

        public RawRequest(Request request) => FromRequest(request);

        public void FromRequest(Request request)
        {
            contexts = request.Contexts;
            query = request.Query;
            lang = "es-ES";
            sessionId = "123456";
            timezone = "Bolivia/Santa_Cruz";
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
