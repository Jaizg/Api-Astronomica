using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;


namespace Datos
{
    public class ContextoDatos
    {
        public static List<Planeta> listaPlanetas = new List<Planeta>()
        {
            new Planeta()
            {
                Id = 1,
                Nombre = "Marte",
                Tipo = "Rocoso",
                Curiosidad = "Tiene el volcan mas grande de todo el sistema solar, llamado Monte Olimpo",
                CantidadLunas = 2,
                TieneAnillos = false
            },
            new Planeta()
            {
                Id = 2,
                Nombre = "Jupiter",
                Tipo = "Gaseoso",
                Curiosidad = "Es tan gigantesco que la Tierra cabría más de 1,300 veces dentro de el",
                CantidadLunas = 95,
                TieneAnillos = true
            },
            new Planeta()
            {
                Id = 3,
                Nombre = "Saturno",
                Tipo = "Gaseoso",
                Curiosidad = "sus anillos estan hechos principalmente de pedazos de hielo y roca",
                CantidadLunas = 146,
                TieneAnillos = true
            }
        };

        public static List<Usuario> listaUsuarios = new List<Usuario>()
        {
            new Usuario
            {
                Id = 1,
                NombreUsuario = "estudiante",
                Contrasena = "123",
                Rol = "Usuario"
            },
            new Usuario
            {
                Id = 2,
                NombreUsuario = "astronomo",
                Contrasena = "astro123",
                Rol = "Astronomo"
            },
            new Usuario
            {
                Id = 3,
                NombreUsuario = "admin",
                Contrasena = "admin123",
                Rol = "Admin"
            }
        };
    }
}