using Antinew.ORM.Framework;
using Antinew.ORM.Framework.Common;
using Antinew.ORM.Framework.Configuration;
using Antinew.ORM.Framework.SqlFilters;
using Antinew.ORM.Framework.SqlMapping;
using Antinew.ORM.Model.DbModel;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Antinew.ORM.DAL
{
    public class SqlHelper
    {

        public T Find<T>(int id) where T:BaseModel
        {
            Type type = typeof(T);
            //string sql_columns = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingName()}]"));
            //string sql_str = $"SELECT {sql_columns} FROM [{type.GetMappingName()}] WHERE ID = {id}";
            string sql_str = $"{SqlBuilder<T>.GetFindSql()}{id}";
            string connection_str = ConnectionStringProvider.GetConnectionString(DBOperation.Read, SlaveStrategy.Polling);
            using (SqlConnection conn = new SqlConnection(connection_str))
            {
                SqlCommand cmd = new SqlCommand(sql_str, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    T t = (T)Activator.CreateInstance(type);
                    foreach (var p in type.GetProperties())
                    {
                        string name = p.GetMappingName(); // 效率差？EF的做法是修改SQL语句AS一下：Code As AntinewCode
                        p.SetValue(t, reader[name] is DBNull ? null : reader[name]);
                    }
                    return t;
                }
            }
            return default(T);
        }
    
        public bool Insert<T>(T t) where T:BaseModel
        {
            Type type = t.GetType();
            string sql_str = SqlBuilder<T>.GetInsertSql();

            var params_array = type.GetProperties()
                .Select(p => new SqlParameter($"@{p.GetMappingName()}", p.GetValue(t) ?? DBNull.Value)).ToArray();
            string connection_str = ConnectionStringProvider.GetConnectionString(DBOperation.Write);
            using (SqlConnection conn = new SqlConnection(connection_str))
            {
                SqlCommand cmd = new SqlCommand(sql_str, conn);
                cmd.Parameters.AddRange(params_array);
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                return res > 0;
            }
        }
    }
}
