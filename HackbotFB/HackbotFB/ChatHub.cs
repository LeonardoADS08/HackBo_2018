using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;
using HackbotFB.Gestiones;
using HackbotFB.Models.Acciones;
using HackbotFB.Models.Hub;
using Microsoft.AspNet.SignalR;

namespace HackbotFB
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChatHub:Hub
    {
       public  static  List<UsuarioConectado> lista=new List<UsuarioConectado>();
        public  void Send(string idfacebook, string mensaje)
        {
            var a = Context.User;
            var mensajito = new Models.Acciones.MensajesTexto();
            mensajito.message = new Mensaje();
            mensajito.recipient = new Recipiente();
            mensajito.message.text = mensaje;
            mensajito.recipient.id = idfacebook;

            Acciones.EnviarMensajeTextoAsync(mensajito);
           // 2119200008150269;
            Console.Beep();
        }
 
        public void desconexion()
        {
            var beee = Context.ConnectionId;
        }
        public void RecibirConexion(string Id)
        {
            UsuarioConectado enLista = lista.FirstOrDefault(x => x.id == Id);
            if (enLista == null)
            {
                var agregar = new UsuarioConectado();
                agregar.id = Id;
                agregar.connectionId = Context.ConnectionId;
                lista.Add(agregar);
            }
            else {
                enLista.connectionId = Id;
            }           
        }
    }
}