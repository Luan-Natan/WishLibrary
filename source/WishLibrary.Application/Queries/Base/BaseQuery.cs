using Dapper;
using System.Data;

namespace WishLibrary.Application.Queries.Base
{
    public static class BaseQuery
    {
        public static IEnumerable<T> DapperSearch<T>(this IDbConnection connection, Dictionary<string, object> query)
        {
            IEnumerable<T> response = null;
            try
            {
                foreach (KeyValuePair<string, object> item in query)
                {
                    connection.Open();
                    var data = connection.Query<dynamic>(item.Key, item.Value);
                    response = (Slapper.AutoMapper.MapDynamic<T>(data) as IEnumerable<T>);
                    Slapper.AutoMapper.Cache.ClearAllCaches();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
