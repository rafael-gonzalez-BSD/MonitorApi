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
    public class ExcepcionController : ControllerBase
    {
        private readonly ExcepcionNegocio n;

        public ExcepcionController(IConfiguration config)
        {
            n = new ExcepcionNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerExcepciones(int Opcion, bool? Baja, DateTime? FechaDesde, DateTime? FechaHasta, int ExcepcionId = 0, int SistemaId = 0, int ExcepcionEstatusId = 1)
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
                {"ExcepcionId", ExcepcionId },
                {"SistemaId", SistemaId },
                {"ExcepcionEstatusId", ExcepcionEstatusId  },
            };
            return await n.ObtenerExcepciones(param);
        }

        [HttpGet("grafico")]
        public async Task<RespuestaModel> ObtenerGraficoExcepciones(DateTime? FechaDesde, bool? Baja, int Opcion = 5, int SistemaId = 0)
        {
            FechaDesde = FechaDesde == null ? DateTime.Today : FechaDesde;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"FechaDesde", FechaDesde },
                {"Baja", Baja },
                {"sistemaId", SistemaId }
            };
            return await n.ObtenerGraficoExcepciones(param);
        }
    }
}