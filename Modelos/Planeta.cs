using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Planeta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } //rocoso, gaseoso, enano
        public string Curiosidad { get; set; }
        public int CantidadLunas { get; set; }
        public bool TieneAnillos { get; set; }
    }
}