using HackbotFB.Models.Tabloides;
using Newtonsoft.Json;
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

        public static bool VerificarRuta(string FacebookId)
        {
            Enrutamiento ruta = new Enrutamiento();
            bool resultado = false;
            using (var db = new Contexto())
            {
                ruta = db.Rutas.FirstOrDefault(x => x.FacebookId == FacebookId);
                if (ruta != null)
                {
                    resultado = false;
                }
                else
                {
                    ruta = new Enrutamiento();
                    ruta.FacebookId = FacebookId;
                    ruta.Nombre = "";
                    ruta.Tipo = "Tipo3";
                    ruta.Conectividad = false;
                    db.Rutas.Add(ruta);
                }
                db.SaveChanges();
                resultado = true;
                
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

        public static string RegistrarSolicitud(Dictionary<string,string> entidades,string FacebookId)
        {
            DateTime ahora = DateTime.Now;
            Solicitudes nueva = new Solicitudes()
            {
                FechaRecepcion = ahora,
                CI = entidades["CI"],
                FacebookId = FacebookId,
                TipoCredito = entidades["Creditos"],
                Ingreso = entidades["Ingreso"],
                Monto = entidades["Monto"],
                ESTADO="PENDIENTE"
            };
            Enrutamiento item = new Enrutamiento();

            using(var db=new Contexto())
            {
                db.Sol.Add(nueva);
                item=db.Rutas.FirstOrDefault(x => x.FacebookId == FacebookId);
                item.Conectividad = true;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return JsonConvert.SerializeObject(nueva);
        }

        public static string ObtenerRuta(string FacebookId)
        {
            string agente = string.Empty;
            using(var db=new Contexto())
            {
                agente = db.Rutas.FirstOrDefault(x => x.FacebookId == FacebookId).AgenteId;
            }
            agente.Replace("////", "//");
            return agente;
        }
    }
}