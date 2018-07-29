using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogFlow.Models
{
    public class Request
    {
        public List<string> Contexts { get; set; }
        public string Query { get; set; }

        public Request(List<string> contexts, string query)
        {
            Contexts = contexts;
            Query = query;
        }

        public void FromRaw(RawRequest raw)
        {
            Contexts = raw.contexts;
            Query = raw.query;
        }

        public string ToJson() => JsonConvert.SerializeObject(new RawRequest(this), Formatting.Indented);
    }
}
