using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Modelos;
using Modelos.DTOs;
using Servicios.Interfaces;


namespace Servicios.Servicios
{
    public class ServicioUsuario : IUsuario
    {
        public List<Usuario> ObtenerAstronomos()
        {
            //retorna solo los usuarios con rol de Astronomo
            return ContextoDatos.listaUsuarios
                .Where(u => u.Rol == "Astronomo")
                .ToList();
        }

        public void CrearAstronomo(UsuarioLoginDTO dto)
        {
            int nuevoId = ContextoDatos.listaUsuarios.Count + 1;

            var nuevoAstronomo = new Usuario
            {
                Id = nuevoId,
                NombreUsuario = dto.NombreUsuario,
                Contrasena = dto.Contrasena,
                Rol = "Astronomo" //se asigna autometicamente el rol
            };

            ContextoDatos.listaUsuarios.Add(nuevoAstronomo);
        }

        public bool EliminarAstronomo(int id)
        {
            var usuario = ContextoDatos.listaUsuarios
                .FirstOrDefault(u => u.Id == id && u.Rol == "Astronomo");

            if (usuario != null)
            {
                ContextoDatos.listaUsuarios.Remove(usuario);
                return true;
            }
            return false;
        }
    }
}