using Datos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos.DTOs;
using Servicios.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Servicios.Servicios
{
    public class ServicioUsuarioAuth : IUsuarioAuth
    {
        private readonly IConfiguration _config;

        public ServicioUsuarioAuth(IConfiguration config)
        {
            _config = config;
        }

        public UsuarioRespuestaLoginDTO Login(UsuarioLoginDTO dto)
        {
            var usuarioEncontrado = ContextoDatos.listaUsuarios
                .FirstOrDefault(u => u.NombreUsuario == dto.NombreUsuario && u.Contrasena == dto.Contrasena);

            if (usuarioEncontrado == null)
            {
                return new UsuarioRespuestaLoginDTO
                {
                    Exitoso = false,
                    Mensaje = "Usuario o contraseña incorrectos",
                    Rol = null
                };
            }

            //Aqui guardamos el usuario y su rol dentro del token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.NombreUsuario),
                new Claim(ClaimTypes.Role, usuarioEncontrado.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: creds
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new UsuarioRespuestaLoginDTO
            {
                Exitoso = true,
                Mensaje = jwtToken, //devolvemos el Token JWT en la respuesta
                NombreUsuario = usuarioEncontrado.NombreUsuario,
                Rol = usuarioEncontrado.Rol
            };
        }
    }
}