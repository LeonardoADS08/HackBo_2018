using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HackbotFB.Models.Tabloides
{
    [Table("Solicitudes")]
    public class Solicitudes
    {
        [Key]
        public int Id { get; set; }

        public string FacebookId { get; set; }

        public string TipoCredito { get; set; }

        public string Monto { get; set; }

        public string CI { get; set; }

        public string Ingreso { get; set; }

        public DateTime FechaRecepcion { get; set; }
    }
}