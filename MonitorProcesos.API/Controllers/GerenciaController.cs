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
    public class GerenciaController : ControllerBase
    {
        private readonly GerenciaNegocio n;

        public GerenciaController(IConfiguration config)
        {
            n = new GerenciaNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerGerencias(int Opcion, int GerenciaId, string GerenciaDescripcion, bool? Baja)
        {
            GerenciaDescripcion = string.IsNullOrEmpty(GerenciaDescripcion) ? "" : GerenciaDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"GerenciaId", GerenciaId },
                {"GerenciaDescripcion", GerenciaDescripcion },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerGerencias(param);
        }

        [HttpGet("combo")]
        public async Task<RespuestaModel> ObtenerComboGerencia(int Opcion, int GerenciaId, string GerenciaDescripcion, bool? Baja)
        {
            GerenciaDescripcion = string.IsNullOrEmpty(GerenciaDescripcion) ? "" : GerenciaDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"GerenciaId", GerenciaId },
                {"GerenciaDescripcion", GerenciaDescripcion },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerComboGerencia(param);
        }

        [HttpGet("by")]
        public async Task<RespuestaModel> ObtenerGerencia(int Opcion, int GerenciaId, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"GerenciaId", GerenciaId },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerGerencia(param);
        }
    }
}