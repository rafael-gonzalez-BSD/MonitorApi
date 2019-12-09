using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorGerencias.Datos.Implementacion
{
    public class GerenciaDao : Disposable
    {
        internal DBConnection _db;

        public GerenciaDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public GerenciaDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<IEnumerable<T>> Consultar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QueryAsync<T>(P, "[dbo].[spGerencia_Consultar]");
        }

        public async Task<T> ConsultarPor<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[dbo].[spGerencia_Consultar]");
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