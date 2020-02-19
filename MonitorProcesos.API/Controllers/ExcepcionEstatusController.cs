using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcepcionEstatusController : ControllerBase
    {
        private readonly ExcepcionEstatusNegocio n;

        public ExcepcionEstatusController(IConfiguration config)
        {
            n = new ExcepcionEstatusNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("combo")]
        public async Task<RespuestaModel> ObtenerComboSistema(int ExcepcionEstatusId, bool? Baja, int Opcion = 3, string ExcepcionEstatusDescripcion = "")
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"ExcepcionEstatusId", ExcepcionEstatusId },
                {"ExcepcionEstatusDescripcion", ExcepcionEstatusDescripcion },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerComboEsxcepcionEstatus(param);
        }
    }
}