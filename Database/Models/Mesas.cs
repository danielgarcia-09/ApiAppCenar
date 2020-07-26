using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Mesas
    {
        public int Id { get; set; }
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
