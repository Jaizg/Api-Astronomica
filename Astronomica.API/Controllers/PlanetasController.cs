using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.DTOs;
using Servicios.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Astronomica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetasController : ControllerBase
    {
        private readonly IPlaneta _servicioPlaneta;

        public PlanetasController(IPlaneta servicioPlaneta)
        {
            this._servicioPlaneta = servicioPlaneta;
        }

        // Cualquier usuario autenticado (Usuario, Astronomo, Admin) puede consultar
        [HttpGet("ObtenerTodosLosPlanetas")]
        [Authorize]
        public IActionResult GetPlanetas()
        {
            return Ok(this._servicioPlaneta.ObtenerPlanetas());
        }

        [HttpGet("GetPlanetaPorId")]
        [Authorize]
        public IActionResult GetPlanetaPorId(int id)
        {
            var planeta = this._servicioPlaneta.ObtenerPlanetas()
                .FirstOrDefault(item => item.Id == id);

            if (planeta == null)
            {
                return NotFound(new { mensaje = "Planeta no encontrado" });
            }

            return Ok(planeta);
        }

        [HttpGet("GetPlanetaPorNombre")]
        [Authorize]
        public IActionResult GetPlanetaPorNombre(string nombre)
        {
            var planetas = this._servicioPlaneta.ObtenerPlanetas()
                .Where(item => item.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();

            return Ok(planetas);
        }

        // Solo Astrónomo o Admin pueden agregar nuevos planetas
        [HttpPost]
        [Authorize(Roles = "Astronomo,Admin")]
        public IActionResult AddPlaneta(PlanetaDTO planetaDto)
        {
            int nuevoId = this._servicioPlaneta.ObtenerPlanetas().Count + 1;

            var planetaBD = new Planeta
            {
                Id = nuevoId,
                Nombre = planetaDto.Nombre,
                Tipo = planetaDto.Tipo,
                Curiosidad = planetaDto.Curiosidad,
                CantidadLunas = planetaDto.CantidadLunas,
                TieneAnillos = planetaDto.TieneAnillos
            };

            this._servicioPlaneta.CrearPlaneta(planetaBD);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Astronomo,Admin")]
        public IActionResult ActualizarPlaneta(int id, [FromBody] PlanetaDTO dto)
        {
            bool actualizado = this._servicioPlaneta.ActualizarPlaneta(id, dto);
            if (!actualizado)
            {
                return NotFound(new { mensaje = "Planeta no encontrado" });
            }
            return Ok(new { mensaje = "Planeta actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Astronomo,Admin")]
        public IActionResult EliminarPlaneta(int id)
        {
            bool eliminado = this._servicioPlaneta.EliminarPlaneta(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = "Planeta no encontrado" });
            }
            return Ok(new { mensaje = "Planeta eliminado exitosamente" });
        }
    }
}