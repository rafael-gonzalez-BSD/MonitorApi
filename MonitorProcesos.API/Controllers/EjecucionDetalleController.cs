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
    public class EjecucionDetalleController : ControllerBase
    {
        private readonly EjecucionDetalleNegocio n;

        public EjecucionDetalleController(IConfiguration config)
        {
            n = new EjecucionDetalleNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerEjecucionDetalles(bool? Baja, int EjecucionDetalleId = 0, int EjecucionId = 0, int Opcion = 4)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"EjecucionDetalleId", EjecucionDetalleId },
                {"EjecucionId", EjecucionId },
                {"Baja", Baja }
        };
            return await n.ObtenerEjecucionDetalles(param);
        }
    }
}