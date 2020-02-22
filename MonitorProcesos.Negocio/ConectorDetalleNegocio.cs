using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using MonitorProcesos.Datos.Implementacion;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Entidad.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcesos.Negocio
{
    public class ConectorDetalleNegocio : Disposable
    {
        private readonly ConectorDetalleDao _dao;
        private RespuestaModel m;

        public ConectorDetalleNegocio(IConfiguration config)
        {
            _dao = new ConectorDetalleDao(config);
            m = new RespuestaModel();
        }

        public ConectorDetalleNegocio(IConfiguration config, string con)
        {
            _dao = new ConectorDetalleDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerConectorDetalles(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<ConectorDetalle>(P);
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
