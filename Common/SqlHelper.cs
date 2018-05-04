using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Common
{
    public class SqlHelper
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static IDbConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }
        private static IDbConnection GetSqlConnection(string connstr)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }

        public static T GetOne<T>(string sql, object param = null)
        {
            try
            {
                T model = default(T);
                using (IDbConnection conn = GetSqlConnection())
                {
                    model = conn.QueryFirstOrDefault<T>(sql, param);
                }
                return model;
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
        public static List<T> GetList<T>(string connstr, string sql, object param = null)
        {
            try
            {
                List<T> list = null;
                using (IDbConnection conn = GetSqlConnection(connstr))
                {
                    list = conn.Query<T>(sql, param).ToList();
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<T> GetList<T>(string sql, object param = null)
        {
            try
            {
                List<T> list = null;
                using (IDbConnection conn = GetSqlConnection())
                {
                    list = conn.Query<T>(sql, param).ToList();
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static PagedTable<T> GetPagedTable<T>(string sql, int limit, int offset, string orderby, string orderway, object param = null)
        {
            PagedTable<T> pt = new PagedTable<T>();
            try
            {
                int total = 0;
                string countSql = "select count(*) from (" + sql + ")t";
                using (IDbConnection conn = GetSqlConnection())
                {
                    object obj = conn.ExecuteScalar(countSql, param);
                    if (obj != null && obj != DBNull.Value)
                    {
                        total = Convert.ToInt32(obj);
                    }
                }
                int start = offset;
                int end = offset + limit + 1;
                if (string.IsNullOrEmpty(orderby))
                {
                    orderby = "Id";
                }
                if (string.IsNullOrEmpty(orderway))
                {
                    orderby = "Desc";
                }
                string pagedSql = "select * from (select row_number() over(order by " + orderby + " " + orderway + ")rownumber,* from (" + sql +
                                  ")t)t1 where rownumber>" + start + " and rownumber<" + end;
                List<T> list = GetList<T>(pagedSql, param);
                pt.total = total;
                pt.rows = list;
                return pt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static int Execute(string sql, object param = null)
        {
            int res = 0;
            using (IDbConnection conn = GetSqlConnection())
            {
                res = conn.Execute(sql, param);
            }
            return res;
        }
        public static T ExecuteScalar<T>(string sql, object param = null)
        {
            T res = default(T);
            using (IDbConnection conn = GetSqlConnection())
            {
                res = conn.ExecuteScalar<T>(sql, param);
            }
            return res;
        }
        public static T ExecuteScalar<T>(IDbConnection conn, string sql, object param = null, IDbTransaction trans = null)
        {
            T res = default(T);
            res = conn.ExecuteScalar<T>(sql, param, trans);
            return res;
        }
        public static int Execute(IDbConnection conn, string sql, object param = null, IDbTransaction trans = null)
        {
            int res = 0;
            res = conn.Execute(sql, param, trans);
            return res;
        }
    }
}
