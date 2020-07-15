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
        public async Task<ObservableCollection<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                ObservableCollection<T> rows = new ObservableCollection<T>(await connection.QueryAsync<T>(sql, parameters).ConfigureAwait(false));

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
    }
}
