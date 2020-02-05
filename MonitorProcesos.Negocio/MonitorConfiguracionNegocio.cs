using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using MonitorProcesos.Datos.Implementacion;
using MonitorProcesos.Entidad.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Negocio
{
    public class MonitorConfiguracionNegocio: Disposable
    {
        private readonly MonitorConfiguracionDao _dao;
        private readonly RespuestaModel m;

        public MonitorConfiguracionNegocio(IConfiguration config)
        {
            _dao = new MonitorConfiguracionDao(config);
            m = new RespuestaModel();
        }

        public MonitorConfiguracionNegocio(IConfiguration config, string con)
        {
            _dao = new MonitorConfiguracionDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerConfiguracion(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.ConsultarPor<MonitorConfiguracion>(P);
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
