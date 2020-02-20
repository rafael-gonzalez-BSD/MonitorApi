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
    public class ConectorNegocio : Disposable
    {
        private readonly ConectorDao _dao;
        private RespuestaModel m;

        public ConectorNegocio(IConfiguration config)
        {
            _dao = new ConectorDao(config);
            m = new RespuestaModel();
        }

        public ConectorNegocio(IConfiguration config, string con)
        {
            _dao = new ConectorDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerConectores(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<Conector>(P);
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

        public async Task<RespuestaModel> ObtenerGraficoConectores(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<GraficoModel>(P);
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
    }
}