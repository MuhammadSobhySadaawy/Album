using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Album.Infrastructure.StaticData
{
    public static class DataTableConverter
    {
        public static DataTable ConvertToDataTable<T>(this IEnumerable<T> dataList) where T : class
        {
            var convertedTable = new DataTable();
            var propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in propertyInfo)
            {
                convertedTable.Columns.Add(prop.Name);
            }
            foreach (var item in dataList)
            {
                var row = convertedTable.NewRow();
                var values = new object[propertyInfo.Length];
                for (var i = 0; i < propertyInfo.Length; i++)
                {
                    var test = propertyInfo[i].GetValue(item, null);
                    row[i] = propertyInfo[i].GetValue(item, null);
                }
                convertedTable.Rows.Add(row);
            }
            return convertedTable;
        }
    }
}
