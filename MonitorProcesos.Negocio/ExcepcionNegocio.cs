﻿using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using MonitorProcesos.Datos.Implementacion;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Entidad.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Negocio
{
    public class ExcepcionNegocio : Disposable
    {
        private readonly ExcepcionDao _dao;
        private RespuestaModel m;

        public ExcepcionNegocio(IConfiguration config)
        {
            _dao = new ExcepcionDao(config);
            m = new RespuestaModel();
        }

        public ExcepcionNegocio(IConfiguration config, string con)
        {
            _dao = new ExcepcionDao(config, con);
            m = new RespuestaModel();
        }

        public async Task<RespuestaModel> ObtenerGraficoExcepciones(Dictionary<string, dynamic> P)
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

        public async Task<RespuestaModel> ObtenerExcepciones(Dictionary<string, dynamic> P)
        {
            try
            {
                var res = await _dao.Consultar<Excepcion>(P);
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