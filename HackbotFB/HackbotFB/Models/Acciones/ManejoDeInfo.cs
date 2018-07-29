using HackbotFB.Models.Tabloides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackbotFB.Models.Acciones
{
    public static class ManejoDeInfo
    {
        public static bool Conectado(string FacebookId)
        {
            bool resultado = false;
            using(var db=new Contexto())
            {
                resultado = db.Rutas.FirstOrDefault(x => x.FacebookId == FacebookId).Conectividad;
            }
            return resultado;
        }

        public static void Conectar(string FacebookId)
        {
            Enrutamiento ruta = new Enrutamiento();
            using(var db=new Contexto())
            {
                ruta = db.Rutas.FirstOrDefault(x => x.FacebookId == FacebookId);
                ruta.Conectividad = true;
                db.Entry(ruta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Desconectar(string FacebookId)
        {
            Enrutamiento ruta = new Enrutamiento();
            using (var db = new Contexto())
            {
                ruta = db.Rutas.FirstOrDefault(x => x.FacebookId == FacebookId);
                ruta.Conectividad = false;
                db.Entry(ruta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void RegistrarSolicitud(Dictionary<string,string> entidades,string FacebookId)
        {
            DateTime ahora = DateTime.Now;
            Solicitudes nueva = new Solicitudes()
            {
                FechaRecepcion = ahora,
                CI = entidades["CI"],
                FacebookId = FacebookId,
                TipoCredito = entidades["Creditos"],
                Ingreso = entidades["Ingreso"],
                Monto = entidades["Monto"]
            };
        }
    }
}