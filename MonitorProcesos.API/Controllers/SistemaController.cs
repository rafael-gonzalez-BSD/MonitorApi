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
    public class SistemaController : ControllerBase
    {
        private readonly SistemaNegocio n;

        public SistemaController(IConfiguration config)
        {
            n = new SistemaNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerSistemas(int Opcion, int SistemaId, string SistemaDescripcion, bool? Baja)
        {
            SistemaDescripcion = string.IsNullOrEmpty(SistemaDescripcion) ? "" : SistemaDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"SistemaId", SistemaId },
                {"SistemaDescripcion", SistemaDescripcion  },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerSistemas(param);
        }

        [HttpGet("combo")]
        public async Task<RespuestaModel> ObtenerComboSistema(int Opcion, int SistemaId, string SistemaDescripcion, bool? Baja)
        {
            SistemaDescripcion = string.IsNullOrEmpty(SistemaDescripcion) ? "" : SistemaDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"SistemaId", SistemaId },
                {"SistemaDescripcion", SistemaDescripcion },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerComboSistema(param);
        }

        [HttpGet("by")]
        public async Task<RespuestaModel> ObtenerSistema(int SistemaId, int Opcion, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"SistemaId", SistemaId },
                {"Baja", Baja }
            };
            return await n.ObtenerSistema(param);
        }

        [HttpPost]        
        public async Task<RespuestaModel> InsertarSistema(Sistema model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"SistemaDescripcion", model.SistemaDescripcion },
                {"Alias", model.Alias },
                {"GerenciaId", model.GerenciaId },
                {"Descripcion", model.Descripcion },
                {"UsuarioCreacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.InsertarSistema(param);
        }

        [HttpPut]
        public async Task<RespuestaModel> ActualizarSistema(Sistema model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"SistemaId", model.SistemaId },
                {"SistemaDescripcion", model.SistemaDescripcion },
                {"Alias", model.Alias },
                {"GerenciaId", model.GerenciaId },
                {"Descripcion", model.Descripcion },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarSistema(param);
        }

        [HttpPatch]
        public async Task<RespuestaModel> ActualizarEstado(Sistema model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"SistemaId", model.SistemaId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarEstado(param);
        }
    }
}