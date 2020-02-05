using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Implementacion
{
    public class MonitorConfiguracionDao: Disposable
    {
        internal DBConnection _db;       

        public MonitorConfiguracionDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public MonitorConfiguracionDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<T> ConsultarPor<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[dbo].[spObtenerConfiguracion_Consultar]");
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
