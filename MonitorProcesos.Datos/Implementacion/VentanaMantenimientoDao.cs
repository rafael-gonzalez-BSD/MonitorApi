using Microsoft.Extensions.Configuration;
using MonitorProcesos.Datos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Implementacion
{
    public class VentanaMantenimientoDao: Disposable
    {
        internal DBConnection _db;

        public VentanaMantenimientoDao(IConfiguration config)
        {
            _db = new DBConnection(config);
        }

        public VentanaMantenimientoDao(IConfiguration config, string con)
        {
            _db = new DBConnection(config, con);
        }

        public async Task<IEnumerable<T>> Consultar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QueryAsync<T>(P, "[Bitacora].[spVentanaMantenimiento_Consultar]");
        }

        public async Task<T> Insertar<T>(Dictionary<string, dynamic> P)
        {
            return await _db.QuerySingleAsync<T>(P, "[Bitacora].[spVentanaMantenimiento_Insertar]");
        }
    }
}
