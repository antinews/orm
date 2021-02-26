using Antinew.ORM.Framework;
using Antinew.ORM.Framework.Common;
using Antinew.ORM.Framework.Configuration;
using Antinew.ORM.Framework.SqlDataValidate;
using Antinew.ORM.Framework.SqlFilters;
using Antinew.ORM.Framework.SqlMapping;
using Antinew.ORM.Model.DbModel;
using Antinew.ORM.Model.ExceptionModels;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Antinew.ORM.DAL
{
    public class SqlHelper
    {

        public T Find<T>(int id) where T:BaseModel, new()
        {
            Type type = typeof(T);
            string sql_str = $"{SqlBuilder<T>.GetFindSql()}{id}";
            string connection_str = ConnectionStringProvider.GetConnectionString(DBOperation.Read, SlaveStrategy.Polling);
            Console.WriteLine($"当前查询使用的数据库链接：{connection_str}");
            using (SqlConnection conn = new SqlConnection(connection_str))
            {
                SqlCommand cmd = new SqlCommand(sql_str, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    T t = new T();
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
    
        public int Insert<T>(T t) where T:BaseModel, new()
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
                object res = cmd.ExecuteScalar();
                return int.TryParse(res.ToString(), out int id)? id : throw new Exception("error:execute insert sql faulty");
            }
        }

        public int Update<T>(T t) where T:BaseModel, new()
        {
            if (!t.Validate())
            {
                throw new ModelValidateException();
            } 
            Type type = typeof(T);
            string columns = string.Join(",", type.GetPropertiesWithoutPrimaryKey().Select(p => $"{p.GetMappingName()}=@{p.Name}"));
            string sql = $"UPDATE [{type.GetMappingName()}] SET {columns} WHERE KeyId = @KeyId";
            var params_array = type.GetProperties().Select(p => new SqlParameter($"@{p.GetMappingName()}", p.GetValue(t) ?? DBNull.Value)).ToArray();
            string connection_str = ConnectionStringProvider.GetConnectionString(DBOperation.Write);
            using (SqlConnection conn = new SqlConnection(connection_str))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(params_array);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
