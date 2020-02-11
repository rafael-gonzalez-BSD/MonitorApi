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
    public class ExcepcionDetalleController : ControllerBase
    {
        private readonly ExcepcionDetalleNegocio n;

        public ExcepcionDetalleController(IConfiguration config)
        {
            n = new ExcepcionDetalleNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerExcepcionDetalles(bool? Baja, int ExcepcionDetalleId = 0, int ExcepcionId = 0, int Opcion = 4)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"ExcepcionDetalleId", ExcepcionDetalleId },
                { "ExcepcionId", ExcepcionId },
                { "Baja", Baja }
        };
            return await n.ObtenerExcepcionDetalles(param);
        }
    }
}