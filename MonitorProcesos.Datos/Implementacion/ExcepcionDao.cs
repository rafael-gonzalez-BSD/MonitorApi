using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Implementacion
{
    public class ExcepcionDao : Disposable
    {
        internal DBConnection _db;

        public ExcepcionDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public ExcepcionDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<IEnumerable<T>> Consultar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QueryAsync<T>(P, "[Bitacora].[spExcepcion_Consultar]");
        }
    }
}