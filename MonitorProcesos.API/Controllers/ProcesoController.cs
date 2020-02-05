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
    public class ProcesoController : ControllerBase
    {
        private readonly ProcesoNegocio n;

        public ProcesoController(IConfiguration config)
        {
            n = new ProcesoNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerProcesos(int Opcion, int SistemaId, int ProcesoId, string ProcesoDescripcion, bool? SistemaBaja, bool? Baja)
        {
            ProcesoDescripcion = string.IsNullOrEmpty(ProcesoDescripcion) ? "" : ProcesoDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"ProcesoId", ProcesoId },
                {"SistemaId", SistemaId },
                {"ProcesoDescripcion", ProcesoDescripcion },
                {"Opcion", Opcion },
                {"Baja", Baja },
                {"SistemaBaja", SistemaBaja}
            };
            return await n.ObtenerProcesos(param);
        }

        [HttpGet("combo")]
        public async Task<RespuestaModel> ObtenerComboProceso(int Opcion, int SistemaId, int ProcesoId, string ProcesoDescripcion, bool? Baja)
        {
            ProcesoDescripcion = string.IsNullOrEmpty(ProcesoDescripcion) ? "" : ProcesoDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"ProcesoId", ProcesoId },
                {"SistemaId", SistemaId },
                {"ProcesoDescripcion", ProcesoDescripcion },
                {"Opcion", Opcion },
                {"Baja", Baja }
            };
            return await n.ObtenerComboProceso(param);
        }

        [HttpGet("by")]
        public async Task<RespuestaModel> ObtenerProceso(int ProcesoId, int Opcion, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"ProcesoId", ProcesoId },
                {"Baja", Baja }
            };
            return await n.ObtenerProceso(param);
        }

        [HttpPost]
        public async Task<RespuestaModel> InsertarProceso(Proceso model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"ProcesoDescripcion", model.ProcesoDescripcion },
                {"Critico", model.Critico },
                {"SistemaId", model.SistemaId },
                {"UsuarioCreacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.InsertarProceso(param);
        }

        [HttpPut]
        public async Task<RespuestaModel> ActualizarProceso(Proceso model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"ProcesoId", model.ProcesoId },
                {"ProcesoDescripcion", model.ProcesoDescripcion },
                {"Critico", model.Critico },
                {"SistemaId", model.SistemaId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarProceso(param);
        }

        [HttpPatch("estado")]
        public async Task<RespuestaModel> ActualizarEstado(Proceso model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"ProcesoId", model.ProcesoId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarEstado(param);
        }
    }
}