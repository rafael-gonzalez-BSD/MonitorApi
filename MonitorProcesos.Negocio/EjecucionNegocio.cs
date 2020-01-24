using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Implementacion;
using MonitorProcesos.Entidad.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcesos.Negocio
{
    public class EjecucionNegocio
    {
        private readonly EjecucionDao _dao;
        private RespuestaModel m;

        public EjecucionNegocio(IConfiguration config)
        {
            _dao = new EjecucionDao(config);
            m = new RespuestaModel();
        }

        public EjecucionNegocio(IConfiguration config, string con)
        {
            _dao = new EjecucionDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerGraficoEjecuciones(Dictionary<string, dynamic> P)
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
