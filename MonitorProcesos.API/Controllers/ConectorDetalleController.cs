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
    public class ConectorDetalleController : ControllerBase
    {
        private readonly ConectorDetalleNegocio n;

        public ConectorDetalleController(IConfiguration config)
        {
            n = new ConectorDetalleNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerConectorDetalles(bool? Baja, int ConectorDetalleId = 0, int ConectorId = 0, int Opcion = 4)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"ConectorDetalleId", ConectorDetalleId },
                {"ConectorId", ConectorId },
                {"Baja", Baja }
            };
            return await n.ObtenerConectorDetalles(param);
        }
    }
}