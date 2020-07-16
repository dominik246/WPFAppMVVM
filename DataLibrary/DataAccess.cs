using Dapper;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = (await connection.QueryAsync<T>(sql, parameters).ConfigureAwait(false)).ToList();

                return rows;
            }
        }

        public async Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters).ConfigureAwait(false);
            }
        }

        public async Task DeleteData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters).ConfigureAwait(false);
            }
        }
    }
}
