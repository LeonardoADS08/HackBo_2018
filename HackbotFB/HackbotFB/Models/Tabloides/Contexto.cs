using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HackbotFB.Models.Tabloides
{
    public class Contexto:DbContext
    {
        public Contexto():
            base("name=BDLOCAL")
        {

        }

        public DbSet<Solicitudes> Sol { get; set; }

        public DbSet<Enrutamiento> Rutas { get; set; }
    }
}