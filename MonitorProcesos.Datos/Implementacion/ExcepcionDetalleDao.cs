using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Implementacion
{
    public class ExcepcionDetalleDao : Disposable
    {
        internal DBConnection _db;

        public ExcepcionDetalleDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public ExcepcionDetalleDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<IEnumerable<T>> Consultar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QueryAsync<T>(P, "[Bitacora].[spExcepcionDetalle_Consultar]");
        }
    }
}