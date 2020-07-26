using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class PlatosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int CantidadPersonas { get; set; }
        public string Ingredientes { get; set; }
        public string Categoria { get; set; }
    }
}
