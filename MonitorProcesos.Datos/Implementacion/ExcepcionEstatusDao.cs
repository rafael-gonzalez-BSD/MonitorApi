using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Implementacion
{
    public class ExcepcionEstatusDao: Disposable
    {
        internal DBConnection _db;

        public ExcepcionEstatusDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public ExcepcionEstatusDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<IEnumerable<T>> Consultar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QueryAsync<T>(P, "[Bitacora].[spExcepcionEstatus_Consultar]");
        }
    }
}
