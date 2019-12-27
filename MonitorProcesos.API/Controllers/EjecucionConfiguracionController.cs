using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Entidad.Modelo;
using MonitorProcesos.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjecucionConfiguracionController : ControllerBase
    {
        private readonly EjecucionConfiguracionNegocio n;

        public EjecucionConfiguracionController(IConfiguration config)
        {
            n = new EjecucionConfiguracionNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerEjecucionConfiguraciones(int Opcion, int SistemaId, int ProcesoId, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"SistemaId", SistemaId },
                {"ProcesoId", ProcesoId },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerEjecucionConfiguraciones(param);
        }

        [HttpGet("by")]
        public async Task<RespuestaModel> ObtenerEjecucionConfiguracion(int EjecucionConfiguracionId, int Opcion, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"EjecucionConfiguracionId", EjecucionConfiguracionId },
                {"Baja", Baja }
            };
            return await n.ObtenerEjecucionConfiguracion(param);
        }

        [HttpPost]
        public async Task<RespuestaModel> InsertarEjecucionConfiguracion(EjecucionConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"Frecuencia", model.Frecuencia },
                {"HoraDesde", model.HoraDesde },
                {"HoraHasta", model.HoraHasta },
                {"RutaLog", model.RutaLog },
                {"TiempoEstimadoEjecucion", model.TiempoEstimadoEjecucion },
                {"TiempoOptimoEjecucion", model.TiempoOptimoEjecucion },
                {"SistemaId", model.SistemaId },
                {"ProcesoId", model.ProcesoId },
                {"UsuarioCreacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.InsertarEjecucionConfiguracion(param);
        }

        [HttpPut]
        public async Task<RespuestaModel> ActualizarEjecucionConfiguracion(EjecucionConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                { "EjecucionConfiguracionId", model.EjecucionConfiguracionId },
                {"Frecuencia", model.Frecuencia },
                {"TiempoEstimadoEjecucion", model.TiempoEstimadoEjecucion },
                {"TiempoOptimoEjecucion", model.TiempoOptimoEjecucion },
                {"RutaLog", model.RutaLog },
                {"HoraDesde", model.HoraDesde },
                {"HoraHasta", model.HoraHasta },
                {"SistemaId", model.SistemaId },
                {"ProcesoId", model.ProcesoId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarEjecucionConfiguracion(param);
        }

        [HttpPatch]
        public async Task<RespuestaModel> ActualizarEstado(EjecucionConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"EjecucionConfiguracionId", model.EjecucionConfiguracionId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarEstado(param);
        }
    }
}