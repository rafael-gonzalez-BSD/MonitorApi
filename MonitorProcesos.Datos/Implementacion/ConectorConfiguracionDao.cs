using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Implementacion
{
    public class ConectorConfiguracionDao : Disposable
    {
        internal DBConnection _db;

        public ConectorConfiguracionDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public ConectorConfiguracionDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<IEnumerable<T>> Consultar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QueryAsync<T>(P, "[Bitacora].[spConectorConfiguracion_Consultar]");
        }

        public async Task<T> ConsultarPor<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[Bitacora].[spConectorConfiguracion_Consultar]");
        }

        public async Task<T> Insertar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[Bitacora].[spConectorConfiguracion_Insertar]");
        }

        public async Task<T> Actualizar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[Bitacora].[spConectorConfiguracion_Actualizar]");
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