using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackbotFB.Models.Acciones
{
    [Serializable]
    public class MensajesTexto
    {
        public Recipiente recipient { get; set; }
        public Mensaje message {get;set;}

        public MensajesTexto()
        {
            recipient = new Recipiente();
            message = new Mensaje();
        }
    }

    [Serializable]
    public class Recipiente
    {
        public string id { get; set; }
    }

    [Serializable]
    public class Mensaje
    {
        public string text { get; set; }
    }
}