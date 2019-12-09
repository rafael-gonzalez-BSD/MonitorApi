using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MonitorProcesos.Datos.Base
{
    public class DBConnection : Disposable
    {
        private readonly string _conexion;

        public DBConnection(IConfiguration config)
        {
            _conexion = config.GetConnectionString("Default").ToString();
        }

        public DBConnection(IConfiguration config, string conexion)
        {
            _conexion = config.GetConnectionString(conexion).ToString();
        }

        public IEnumerable<T> Query<T>(Dictionary<string, dynamic> P, string SP)
        {
            using (IDbConnection con = new SqlConnection(_conexion))
            {
                DynamicParameters DP = new DynamicParameters();

                foreach (KeyValuePair<string, dynamic> item in P)
                {
                    DP.Add(item.Key, item.Value);
                }

                return con.Query<T>(SP, param: DP, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(Dictionary<string, dynamic> P, string SP)
        {
            using (IDbConnection con = new SqlConnection(_conexion))
            {
                DynamicParameters DP = new DynamicParameters();

                foreach (KeyValuePair<string, dynamic> item in P)
                {
                    DP.Add(item.Key, item.Value);
                }

                return await con.QueryAsync<T>(SP, param: DP, commandType: CommandType.StoredProcedure);
            }
        }

        public T QuerySingle<T>(Dictionary<string, dynamic> P, string SP)
        {
            using (IDbConnection conn = new SqlConnection(_conexion))
            {
                DynamicParameters DP = new DynamicParameters();

                foreach (KeyValuePair<string, dynamic> item in P)
                {
                    DP.Add(item.Key, item.Value);
                }
                return conn.QueryFirst<T>(SP, param: DP, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> QuerySingleAsync<T>(Dictionary<string, dynamic> P, string SP)
        {
            using (IDbConnection conn = new SqlConnection(_conexion))
            {
                DynamicParameters DP = new DynamicParameters();

                foreach (KeyValuePair<string, dynamic> item in P)
                {
                    DP.Add(item.Key, item.Value);
                }
                return await conn.QueryFirstAsync<T>(SP, param: DP, commandType: CommandType.StoredProcedure);
            }
        }
    }
}