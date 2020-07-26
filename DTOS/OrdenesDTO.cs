using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class OrdenesDTO
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public string PlatosSeleccionados { get; set; }
        public int SubTotal { get; set; }
        public string Estado { get; set; }
    }
}
