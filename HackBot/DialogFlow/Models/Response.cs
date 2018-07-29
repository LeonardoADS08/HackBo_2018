using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogFlow.Models
{
    public class Response
    {
        Dictionary<string, string> Entities { get; set; }
        public string Answer { get; set; }

        public Response(RawResponse raw) => FromRaw(raw);

        public void FromRaw(RawResponse raw)
        {
            Entities = raw.result.parameters;
            Answer = raw.result.fulfillment.speech;
        }

    }
}
