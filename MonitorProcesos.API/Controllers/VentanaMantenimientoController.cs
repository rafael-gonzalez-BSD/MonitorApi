﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Entidad.Modelo;
using MonitorProcesos.Negocio;

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
        public async Task<RespuestaModel> ObtenerVentanaMantenimientos(int Opcion, int VentanaMantenimientoId, int SistemaId, DateTime? FechaDesde, DateTime? FechaHasta, bool? Baja)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Opcion", Opcion },
                {"VentanaMantenimientoId", VentanaMantenimientoId },
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