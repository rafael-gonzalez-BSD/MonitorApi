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
    public class ExcepcionController : ControllerBase
    {
        private readonly ExcepcionNegocio n;

        public ExcepcionController(IConfiguration config)
        {
            n = new ExcepcionNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("grafico")]
        public async Task<RespuestaModel> ObtenerGraficoSistema(DateTime? FechaOcurrencia, bool? Baja, int Opcion = 5, int ExcepcionId = 0)
        {
            FechaOcurrencia = FechaOcurrencia == null ? DateTime.Today : FechaOcurrencia;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"ExcepcionId", ExcepcionId },
                {"FechaOcurrencia", FechaOcurrencia },
                {"Baja", Baja }
            };
            return await n.ObtenerGraficoExcepciones(param);
        }
    }
}