using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Ordenes
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public string PlatosSeleccionados { get; set; }
        public int SubTotal { get; set; }
        public string Estado { get; set; }
    }
}
