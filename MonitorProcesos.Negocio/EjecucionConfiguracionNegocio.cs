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
    public class EjecucionConfiguracionNegocio : Disposable
    {
        private readonly EjecucionConfiguracionDao _dao;
        private RespuestaModel m;

        public EjecucionConfiguracionNegocio(IConfiguration config)
        {
            _dao = new EjecucionConfiguracionDao(config);
            m = new RespuestaModel();
        }

        public EjecucionConfiguracionNegocio(IConfiguration config, string con)
        {
            _dao = new EjecucionConfiguracionDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerEjecucionConfiguraciones(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<EjecucionConfiguracion>(P);
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

        //public async Task<RespuestaModel> ObtenerComboProceso(Dictionary<string, dynamic> P)
        //{
        //    try
        //    {
        //        var res = await _dao.Consultar<ComboModel>(P);
        //        m.Datos = res;
        //        m.Satisfactorio = true;
        //        m.Id = 0;
        //        m.Mensaje = "";
        //        m.ErrorId = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        m.Datos = null;
        //        m.Satisfactorio = false;
        //        m.Id = 0;
        //        m.Mensaje = "No se pudo realizar la solicitud. " + ex.Message + ". " + ex.InnerException;
        //        m.ErrorId = 500;
        //    }
        //    return m;
        //}

        public async Task<RespuestaModel> ObtenerEjecucionConfiguracion(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.ConsultarPor<EjecucionConfiguracion>(P);
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

        public async Task<RespuestaModel> InsertarEjecucionConfiguracion(Dictionary<string, dynamic> P)
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

        public async Task<RespuestaModel> ActualizarEjecucionConfiguracion(Dictionary<string, dynamic> P)
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