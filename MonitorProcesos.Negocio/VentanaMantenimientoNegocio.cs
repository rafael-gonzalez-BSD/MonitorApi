using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using MonitorProcesos.Datos.Implementacion;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Entidad.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Negocio
{
    public class VentanaMantenimientoNegocio : Disposable
    {
        private readonly VentanaMantenimientoDao _dao;
        private RespuestaModel m;

        public VentanaMantenimientoNegocio(IConfiguration config)
        {
            _dao = new VentanaMantenimientoDao(config);
            m = new RespuestaModel();
        }

        public VentanaMantenimientoNegocio(IConfiguration config, string con)
        {
            _dao = new VentanaMantenimientoDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerVentanaMantenimientos(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<VentanaMantenimiento>(P);
                m.Datos = res;
                m.Satisfactorio = true;
                m.Id = 0;
                m.Mensaje = "";
                m.ErrorId = 0;
            }
            catch (Exception ex)
            {
                m.Datos = null;
                m.Satisfactorio = false;
                m.Id = 0;
                m.Mensaje = "No se pudo realizar la solicitud. " + ex.Message + ". " + ex.InnerException;
                m.ErrorId = 500;
            }
            return m;
        }

        public async Task<RespuestaModel> ObtenerVentanaMantenimiento(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.ConsultarPor<VentanaMantenimiento>(P);
                m.Datos = res;
                m.Satisfactorio = true;
                m.Id = 0;
                m.Mensaje = "";
                m.ErrorId = 0;
            }
            catch (Exception ex)
            {
                m.Datos = null;
                m.Satisfactorio = false;
                m.Id = 0;
                m.Mensaje = "No se pudo realizar la solicitud. " + ex.Message + ". " + ex.InnerException;
                m.ErrorId = 500;
            }
            return m;
        }

        public async Task<RespuestaModel> InsertarVentanaMantenimiento(Dictionary<string, dynamic> P)
        {
            try
            {
                m = await _dao.Insertar<RespuestaModel>(P);
            }
            catch (Exception ex)
            {
                m.Id = 0;
                m.ErrorId = -2;
                m.Satisfactorio = false;
                m.Datos = null;
                m.Mensaje = ex.Message + ". " + ex.InnerException;
            }

            return m;
        }

        public async Task<RespuestaModel> ActualizarVentanaMantenimiento(Dictionary<string, dynamic> P)
        {
            try
            {
                m = await _dao.Actualizar<RespuestaModel>(P);
            }
            catch (Exception ex)
            {
                m.Id = 0;
                m.ErrorId = -2;
                m.Satisfactorio = false;
                m.Datos = null;
                m.Mensaje = ex.Message + ". " + ex.InnerException;
            }

            return m;
        }

        public async Task<RespuestaModel> ActualizarEstado(Dictionary<string, dynamic> P)
        {
            try
            {
                m = await _dao.Actualizar<RespuestaModel>(P);
            }
            catch (Exception ex)
            {
                m.Id = 0;
                m.ErrorId = -2;
                m.Satisfactorio = false;
                m.Datos = null;
                m.Mensaje = ex.Message + ". " + ex.InnerException;
            }

            return m;
        }

        protected override void DisposeCore()
        {
            if (_dao != null)
            {
                _dao.Dispose();
            }
            Dispose();
        }
    }
}