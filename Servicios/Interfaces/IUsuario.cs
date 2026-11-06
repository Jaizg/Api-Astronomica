using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Modelos.DTOs;

namespace Servicios.Interfaces
{
    public interface IUsuario
    {
        List<Usuario> ObtenerAstronomos();
        void CrearAstronomo(UsuarioLoginDTO dto);
        bool EliminarAstronomo(int id);
    }
}