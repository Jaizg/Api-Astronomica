using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.DTOs;
using Servicios.Interfaces;

namespace Astronomica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Todo este controlador es exclusivo para el Admin
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _servicioUsuario;

        public UsuariosController(IUsuario servicioUsuario)
        {
            this._servicioUsuario = servicioUsuario;
        }

        [HttpGet("ObtenerAstronomos")]
        public IActionResult ObtenerAstronomos()
        {
            return Ok(this._servicioUsuario.ObtenerAstronomos());
        }

        [HttpPost("CrearAstronomo")]
        public IActionResult CrearAstronomo([FromBody] UsuarioLoginDTO dto)
        {
            this._servicioUsuario.CrearAstronomo(dto);
            return StatusCode(StatusCodes.Status201Created, new { mensaje = "Astrónomo creado exitosamente" });
        }

        [HttpDelete("EliminarAstronomo/{id}")]
        public IActionResult EliminarAstronomo(int id)
        {
            bool eliminado = this._servicioUsuario.EliminarAstronomo(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = "No se encontró el astrónomo especificado" });
            }
            return Ok(new { mensaje = "Astrónomo eliminado exitosamente" });
        }
    }
}