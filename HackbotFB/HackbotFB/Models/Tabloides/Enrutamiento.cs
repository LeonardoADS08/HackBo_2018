using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HackbotFB.Models.Tabloides
{
    [Table("Enrutamiento")]
    public class Enrutamiento
    {
        [Key]
        public string FacebookId { get; set; }

        public string AgenteId { get; set; }

        public bool Conectividad { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }
    }
}