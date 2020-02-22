using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Negocio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjecucionController : ControllerBase
    {
        private readonly EjecucionNegocio n;

        public EjecucionController(IConfiguration config)
        {
            n = new EjecucionNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerEjecuciones(int Opcion, bool? Baja, DateTime? FechaDesde, DateTime? FechaHasta, int EjecucionId = 0, int SistemaId = 0, int ProcesoId = 0)
        {
            if (FechaDesde != null && FechaHasta == null)
            {
                FechaHasta = FechaDesde;
            }
            else if (FechaHasta != null && FechaDesde == null)
            {
                FechaDesde = FechaHasta;
            }

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"Baja", Baja },
                {"FechaDesde", FechaDesde },
                {"FechaHasta", FechaHasta },
                {"EjecucionId", EjecucionId },
                {"SistemaId", SistemaId },
                {"ProcesoId", ProcesoId  },
            };

            return await n.ObtenerEjecuciones(param);
        }

        [HttpGet("grafico")]
        public async Task<RespuestaModel> ObtenerGraficoEjecuciones(DateTime FechaDesde, DateTime FechaHasta, bool? Baja, int Opcion = 5, int SistemaId = 0)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"FechaDesde", FechaDesde },
                {"FechaHasta", FechaHasta },
                {"Baja", Baja },
                {"sistemaId", SistemaId }
            };
            return await n.ObtenerGraficoEjecuciones(param);
        }
    }
}