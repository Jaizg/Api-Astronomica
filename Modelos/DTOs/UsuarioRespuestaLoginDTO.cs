using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTOs
{
    public class UsuarioRespuestaLoginDTO
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
    }
}