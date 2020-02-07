using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using MonitorProcesos.Datos.Implementacion;
using MonitorProcesos.Entidad.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcesos.Negocio
{
    public class ExcepcionEstatusNegocio: Disposable
    {
        private readonly ExcepcionEstatusDao _dao;
        private RespuestaModel m;

        public ExcepcionEstatusNegocio(IConfiguration config)
        {
            _dao = new ExcepcionEstatusDao(config);
            m = new RespuestaModel();
        }

        public ExcepcionEstatusNegocio(IConfiguration config, string con)
        {
            _dao = new ExcepcionEstatusDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerComboEsxcepcionEstatus(Dictionary<string, dynamic> P)
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
    }
}
