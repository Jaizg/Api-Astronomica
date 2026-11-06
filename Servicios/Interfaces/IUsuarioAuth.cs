using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.DTOs;

namespace Servicios.Interfaces
{
    public interface IUsuarioAuth
    {
        UsuarioRespuestaLoginDTO Login(UsuarioLoginDTO dto);
    }
}