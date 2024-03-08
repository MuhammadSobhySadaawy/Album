using Album.DataAccess;
using Album.DataAccess.Repository_Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.DataAccess.Repository.DefualtRepository
{
    public class SPProvider : ISPProvider
    {

        private readonly ApplicationDbContext _context;
        private static string _connectionString = string.Empty;

        public SPProvider(ApplicationDbContext context)
        {
            _context = context;
            _connectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public async Task<T> ExecuteScaler<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();

                return (T)Convert.ChangeType(await con.ExecuteScalarAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public async Task<int> ExecuteWithStatus(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.ExecuteAsync(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<T> ReturnShortLeaveBalanceByEmployee<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryFirstOrDefaultAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<T> ReturnLoansPolicy<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryFirstOrDefaultAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<List<IDictionary<string, object>>> ReturnView<dynamic>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                var result = con.Query<dynamic>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure).ToList();

                return result.Select(x => (IDictionary<string, object>)x).ToList();
                //return await con.QueryAsync<dynamic>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<string> ReturnString(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryFirstOrDefaultAsync<string>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<T>> ReturnBalancePolicyData<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<T> ReturnFirstOrDefault<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryFirstOrDefaultAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
