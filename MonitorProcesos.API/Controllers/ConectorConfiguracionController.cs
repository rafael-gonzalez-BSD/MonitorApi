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
    public class ConectorConfiguracionController : ControllerBase
    {
        private readonly ConectorConfiguracionNegocio n;

        public ConectorConfiguracionController(IConfiguration config)
        {
            n = new ConectorConfiguracionNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerConectorConfiguraciones(int Opcion, int SistemaId, int ConectorConfiguracionId, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"SistemaId", SistemaId },
                { "ConectorConfiguracionId", ConectorConfiguracionId },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerConectorConfiguraciones(param);
        }

        [HttpGet("combo")]
        public async Task<RespuestaModel> ObtenerComboConectorConfiguracion(int Opcion, int SistemaId, int ConectorConfiguracionId, string ConectorConfiguracionDescripcion, bool? Baja)
        {
            ConectorConfiguracionDescripcion = string.IsNullOrEmpty(ConectorConfiguracionDescripcion) ? "" : ConectorConfiguracionDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"ConectorConfiguracionId", ConectorConfiguracionId },
                {"ConectorConfiguracionDescripcion", ConectorConfiguracionDescripcion },
                {"SistemaId", SistemaId },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerComboConectorConfiguracion(param);
        }

        [HttpGet("by")]
        public async Task<RespuestaModel> ObtenerConectorConfiguracion(int ConectorConfiguracionId, int Opcion, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"ConectorConfiguracionId", ConectorConfiguracionId },
                {"Baja", Baja }
            };
            return await n.ObtenerConectorConfiguracion(param);
        }

        [HttpPost]
        public async Task<RespuestaModel> InsertarConectorConfiguracion(ConectorConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"ConectorConfiguracionDescripcion", model.ConectorConfiguracionDescripcion },
                {"UrlApi", model.UrlApi },
                {"Frecuencia", model.Frecuencia },
                {"HoraDesde", model.HoraDesde },
                {"HoraHasta", model.HoraHasta },
                {"SistemaId", model.SistemaId },
                {"UsuarioCreacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.InsertarConectorConfiguracion(param);
        }

        [HttpPut]
        public async Task<RespuestaModel> ActualizarConectorConfiguracion(ConectorConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                { "ConectorConfiguracionId", model.ConectorConfiguracionId },
                {"ConectorConfiguracionDescripcion", model.ConectorConfiguracionDescripcion },
                {"UrlApi", model.UrlApi },
                {"Frecuencia", model.Frecuencia },
                {"HoraDesde", model.HoraDesde },
                {"HoraHasta", model.HoraHasta },
                {"SistemaId", model.SistemaId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarConectorConfiguracion(param);
        }

        [HttpPatch]
        public async Task<RespuestaModel> ActualizarEstado(ConectorConfiguracion model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"ConectorConfiguracionId", model.ConectorConfiguracionId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarEstado(param);
        }
    }
}