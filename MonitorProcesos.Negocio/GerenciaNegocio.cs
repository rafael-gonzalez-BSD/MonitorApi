using Microsoft.Extensions.Configuration;
using MonitorGerencias.Datos.Implementacion;
using MonitorProcesos.Datos.Base;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Entidad.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Negocio
{
    public class GerenciaNegocio : Disposable
    {
        private readonly GerenciaDao _dao;
        private readonly RespuestaModel m;

        public GerenciaNegocio(IConfiguration config)
        {
            _dao = new GerenciaDao(config);
            m = new RespuestaModel();
        }

        public GerenciaNegocio(IConfiguration config, string con)
        {
            _dao = new GerenciaDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerGerencias(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<Gerencia>(P);
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

        public async Task<RespuestaModel> ObtenerGerencia(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.ConsultarPor<Gerencia>(P);
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

        public async Task<RespuestaModel> ObtenerComboGerencia(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<ComboModel>(P);
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