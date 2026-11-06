using Datos;
using Modelos;
using Modelos.DTOs;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class ServicioPlaneta : IPlaneta
    {
        public List<Planeta> ObtenerPlanetas()
        {
            return ContextoDatos.listaPlanetas;
        }

        public void CrearPlaneta(Planeta planeta)
        {
            ContextoDatos.listaPlanetas.Add(planeta);
        }
        public bool ActualizarPlaneta(int id, PlanetaDTO dto)
        {
            var planeta = ContextoDatos.listaPlanetas.FirstOrDefault(p => p.Id == id);
            if (planeta == null) return false;

            planeta.Nombre = dto.Nombre;
            planeta.Tipo = dto.Tipo;
            planeta.Curiosidad = dto.Curiosidad;
            planeta.CantidadLunas = dto.CantidadLunas;
            planeta.TieneAnillos = dto.TieneAnillos;

            return true;
        }

        public bool EliminarPlaneta(int id)
        {
            var planeta = ContextoDatos.listaPlanetas.FirstOrDefault(p => p.Id == id);
            if (planeta == null) return false;

            ContextoDatos.listaPlanetas.Remove(planeta);
            return true;
        }
    }
}