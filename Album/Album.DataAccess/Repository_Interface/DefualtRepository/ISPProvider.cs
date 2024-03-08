using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.DataAccess.Repository_Interface
{
    public interface ISPProvider : IDisposable
    {
        Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null);
        Task<T> ReturnFirstOrDefault<T>(string procedureName, DynamicParameters param = null);
        Task<int> ExecuteWithStatus(string procedureName, DynamicParameters param = null);

        Task<string> ReturnString(string procedureName, DynamicParameters param = null);


        Task<T> ExecuteScaler<T>(string procedureName, DynamicParameters param = null);
        Task<List<IDictionary<string, object>>> ReturnView<dynamic>(string procedureName, DynamicParameters param = null);
        Task<IEnumerable<dynamic>> ReturnBalancePolicyData<dynamic>(string procedureName, DynamicParameters param = null);
        Task<T> ReturnShortLeaveBalanceByEmployee<T>(string procedureName, DynamicParameters param = null);
        Task<T> ReturnLoansPolicy<T>(string procedureName, DynamicParameters param = null);

    }
}
