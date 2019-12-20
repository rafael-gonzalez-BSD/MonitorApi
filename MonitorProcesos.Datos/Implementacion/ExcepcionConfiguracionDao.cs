using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Implementacion
{
    public class ExcepcionConfiguracionDao: Disposable
    {
        internal DBConnection _db;

        public ExcepcionConfiguracionDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public ExcepcionConfiguracionDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<IEnumerable<T>> Consultar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QueryAsync<T>(P, "[dbo].[spExcepcionConfiguracion_Consultar]");
        }

        public async Task<T> ConsultarPor<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[dbo].[spExcepcionConfiguracion_Consultar]");
        }

        public async Task<T> Insertar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[dbo].[spExcepcionConfiguracion_Insertar]");
        }

        public async Task<T> Actualizar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[dbo].[spExcepcionConfiguracion_Actualizar]");
        }

        protected override void DisposeCore()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            Dispose();
        }
    }
}
