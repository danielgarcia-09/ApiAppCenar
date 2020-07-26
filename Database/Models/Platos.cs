using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Platos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int CantidadPersonas { get; set; }
        public string Ingredientes { get; set; }
        public string Categoria { get; set; }

    }
}
