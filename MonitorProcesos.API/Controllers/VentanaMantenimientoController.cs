using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Entidad.Modelo;
using MonitorProcesos.Negocio;
using System;
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
        public async Task<RespuestaModel> ObtenerVentanaMantenimientos(int Opcion, int SistemaId, DateTime? FechaDesde, DateTime? FechaHasta, bool? SistemaBaja, bool? Baja, int VentanaMantenimientoId = 0)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"SistemaId", SistemaId },
                {"FechaDesde", FechaDesde },
                {"FechaHasta", FechaHasta },
                {"Baja", Baja },
                {"SistemaBaja", SistemaBaja},
                {"VentanaMantenimientoId", VentanaMantenimientoId}
            };
            return await n.ObtenerVentanaMantenimientos(param);
        }

        [HttpGet("by")]
        public async Task<RespuestaModel> ObtenerVentanaMantenimiento(int VentanaMantenimientoId, int SistemaId, int Opcion, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"VentanaMantenimientoId", VentanaMantenimientoId },
                {"SistemaId", SistemaId },
                {"Baja", Baja }
            };
            return await n.ObtenerVentanaMantenimiento(param);
        }

        [HttpPost]
        public async Task<RespuestaModel> InsertarVentanaMantenimiento(VentanaMantenimiento model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"SistemaId", model.SistemaId },
                {"FechaDesde", model.FechaDesde },
                {"HoraDesde", model.HoraDesde },
                {"FechaHasta", model.FechaHasta },
                {"HoraHasta", model.HoraHasta },
                {"UsuarioCreacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.InsertarVentanaMantenimiento(param);
        }

        [HttpPut]
        public async Task<RespuestaModel> ActualizarExcepcionConfiguracion(VentanaMantenimiento model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                { "VentanaMantenimientoId", model.VentanaMantenimientoId },
                {"SistemaId", model.SistemaId },
                {"FechaDesde", model.FechaDesde },
                {"HoraDesde", model.HoraDesde },
                {"FechaHasta", model.FechaHasta },
                {"HoraHasta", model.HoraHasta },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarVentanaMantenimiento(param);
        }

        [HttpPatch]
        public async Task<RespuestaModel> ActualizarEstado(VentanaMantenimiento model)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", model.Opcion },
                {"VentanaMantenimientoId", model.VentanaMantenimientoId },
                {"UsuarioModificacionId", 1 },
                {"Baja", model.Baja }
            };
            return await n.ActualizarEstado(param);
        }
    }
}