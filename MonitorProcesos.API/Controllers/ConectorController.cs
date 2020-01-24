using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Negocio;

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
        public async Task<RespuestaModel> ObtenerGraficoConectores(DateTime? FechaOcurrencia, bool? Baja, int Opcion = 5, int SistemaId = 0)
        {
            FechaOcurrencia = FechaOcurrencia == null ? DateTime.Today : FechaOcurrencia;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"FechaOcurrencia", FechaOcurrencia },
                {"Baja", Baja },
                {"sistemaId", SistemaId }
            };
            return await n.ObtenerGraficoConectores(param);
        }
    }
}