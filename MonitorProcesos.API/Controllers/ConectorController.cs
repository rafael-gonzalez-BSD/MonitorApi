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
    public class ConectorController : ControllerBase
    {
        private readonly ConectorNegocio n;

        public ConectorController(IConfiguration config)
        {
            n = new ConectorNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("grafico")]
        public async Task<RespuestaModel> ObtenerGraficoConectores(DateTime? FechaDesde, DateTime? FechaHasta, bool? Baja, int Opcion = 5, int SistemaId = 0)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"FechaDesde", FechaDesde },
                {"FechaHasta", FechaHasta },
                {"Baja", Baja },
                {"sistemaId", SistemaId }
            };
            return await n.ObtenerGraficoConectores(param);
        }
    }
}