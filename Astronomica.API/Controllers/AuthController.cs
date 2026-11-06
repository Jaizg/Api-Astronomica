using Microsoft.AspNetCore.Mvc;
using Modelos.DTOs;
using Servicios.Interfaces;

namespace Astronomica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioAuth _servicioAuth;

        public AuthController(IUsuarioAuth servicioAuth)
        {
            this._servicioAuth = servicioAuth;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginDTO usuarioDto)
        {
            var resultado = this._servicioAuth.Login(usuarioDto);

            if (!resultado.Exitoso)
            {
                return Unauthorized(resultado);
            }

            return Ok(resultado);
        }
    }
}