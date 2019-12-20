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
    public class VentanaMantenimientoController : ControllerBase
    {
        private readonly VentanaMantenimientoNegocio n;

        public VentanaMantenimientoController(IConfiguration config)
        {
            n = new VentanaMantenimientoNegocio(config, "MonitorRemoteDev");
        }

        [HttpGet("all")]
        public async Task<RespuestaModel> ObtenerProcesos(int Opcion, int VentanaMantenimientoId, string VentanaMantenimientoDescripcion, int SistemaId, int FechaDesde, string FechaHasta, bool? Baja)
        {
            VentanaMantenimientoDescripcion = string.IsNullOrEmpty(VentanaMantenimientoDescripcion) ? "" : VentanaMantenimientoDescripcion;
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"VentanaMantenimientoId", VentanaMantenimientoId },
                {"VentanaMantenimientoDescripcion", VentanaMantenimientoDescripcion },
                {"SistemaId", SistemaId },
                {"FechaDesde", FechaDesde },
                {"FechaHasta", FechaHasta },
                {"Baja", Baja }
            };
            return await n.ObtenerVentanaMantenimientos(param);
        }

        [HttpPost]
        public async Task<RespuestaModel> InsertarVentanaMantenimiento(VentanaMantenimiento model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"SistemaId", model.SistemaId },
                {"FechaDesde", model.FechaDesde },
                {"FechaHasta", model.FechaHasta },
                {"UsuarioCreacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.InsertarVentanaMantenimiento(param);
        }
    }
}