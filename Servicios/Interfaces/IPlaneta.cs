using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Modelos.DTOs;

namespace Servicios.Interfaces
{
    public interface IPlaneta
    {
        List<Planeta> ObtenerPlanetas();
        void CrearPlaneta(Planeta planeta);
        bool ActualizarPlaneta(int id, PlanetaDTO dto);
        bool EliminarPlaneta(int id);
    }
}