using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTOs
{
    public class PlanetaDTO
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Curiosidad { get; set; }
        public int CantidadLunas { get; set; }
        public bool TieneAnillos { get; set; }
    }
}