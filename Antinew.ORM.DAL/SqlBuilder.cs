using Antinew.ORM.Framework.SqlFilters;
using Antinew.ORM.Framework.SqlMapping;
using Antinew.ORM.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Antinew.ORM.DAL
{
    /// <summary>
    /// 缓存sql语句。泛型缓存特性：类型副本--达到一个表只使用一个缓存对象
    /// 每张表都是一些固定的sql语句
    /// 第一次调用静态方法执行顺序：静态字段->静态构造函数->构造函数->静态方法 
    /// </summary>
    class SqlBuilder<T> where T:BaseModel
    {
        private static string _findSql;
        private static string _insertSql;
        static SqlBuilder()
        {
            var type = typeof(T);
            {
                string sql_columns = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingName()}]"));
                _findSql = $"SELECT {sql_columns} FROM [{type.GetMappingName()}] WHERE KeyID = ";
            }
            {
                string sql_columns = string.Join(",", type.GetPropertiesWithoutPrimaryKey().Select(p => $"[{p.GetMappingName()}]"));
                //不能直接拼装值--防Sql注入
                string sql_values = string.Join(",", type.GetPropertiesWithoutPrimaryKey().Select(p => $"@{p.GetMappingName()}"));
                _insertSql = $"INSERT INTO [{type.GetMappingName()}]({sql_columns}) VALUES({sql_values}) SELECT @@Identity";
            }
        }

        /// <summary>
        /// 以Id= 结尾，可以直接添加参数
        /// </summary>
        /// <returns></returns>
        public static string GetFindSql() => _findSql;

        /// <summary>
        /// 插入sql通用
        /// </summary>
        /// <returns></returns>
        public static string GetInsertSql() => _insertSql;
    }
}
