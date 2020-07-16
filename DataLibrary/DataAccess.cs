using Dapper;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

                if(rows.Count == 0)
                {
                    await InitialLaunch(connectionString);
                    rows = (await connection.QueryAsync<T>(sql, parameters).ConfigureAwait(false)).ToList();
                }

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

        private async Task InitialLaunch(string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string sql = "INSERT INTO [dbo].[Users] ([LastName] ,[FirstName] ,[City] ,[State] ,[Country]) VALUES " +
                                       "('Raj', 'Beniwal', 'Delhi', 'DEL', 'INDIA'), " +
                                       "('Mark', 'Henry', 'New York', 'NY', 'USA'), " +
                                       "('Mahesh', 'Chand', 'Philadelphia', 'PHL', 'USA'), " +
                                       "('Vikash', 'Nanda', 'Noida', 'UP', 'INDIA'), " +
                                       "('Reetesh', 'Tomar', 'Mumbai', 'MP', 'INDIA'), " +
                                       "('Deven', 'Verma', 'Palwal', 'HP', 'INDIA'), " +
                                       "('Ravi', 'Taneja', 'Delhi', 'DEL', 'INDIA')";

                await connection.ExecuteAsync(sql, new { }).ConfigureAwait(false);
            }
        }
    }
}
