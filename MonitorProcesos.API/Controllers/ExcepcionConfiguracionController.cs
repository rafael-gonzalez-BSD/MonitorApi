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
    public class ExcepcionConfiguracionController : ControllerBase
    {
        private readonly ExcepcionConfiguracionNegocio n;

        public ExcepcionConfiguracionController(IConfiguration config)
        {
            n = new ExcepcionConfiguracionNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerExcepcionConfiguraciones(int Opcion, int SistemaId, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"SistemaId", SistemaId },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerExcepcionConfiguraciones(param);
        }

        [HttpGet("by")]
        public async Task<RespuestaModel> ObtenerExcepcionConfiguracion(int ExcepcionConfiguracionId, int Opcion, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"ExcepcionConfiguracionId", ExcepcionConfiguracionId },
                {"Baja", Baja }
            };
            return await n.ObtenerExcepcionConfiguracion(param);
        }

        [HttpPost]
        public async Task<RespuestaModel> InsertarExcepcionConfiguracion(ExcepcionConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"Frecuencia", model.Frecuencia },
                {"RutaLog", model.RutaLog },
                {"HoraDesde", model.HoraDesde },
                {"HoraHasta", model.HoraHasta },
                {"SistemaId", model.SistemaId },
                {"UsuarioCreacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.InsertarExcepcionConfiguracion(param);
        }

        [HttpPut]
        public async Task<RespuestaModel> ActualizarExcepcionConfiguracion(ExcepcionConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                { "ExcepcionConfiguracionId", model.ExcepcionConfiguracionId },
                {"Frecuencia", model.Frecuencia },
                {"RutaLog", model.RutaLog },
                {"HoraDesde", model.HoraDesde },
                {"HoraHasta", model.HoraHasta },
                {"SistemaId", model.SistemaId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarExcepcionConfiguracion(param);
        }

        [HttpPatch]
        public async Task<RespuestaModel> ActualizarEstado(ExcepcionConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"ExcepcionConfiguracionId", model.ExcepcionConfiguracionId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarEstado(param);
        }
    }
}