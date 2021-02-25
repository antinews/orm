using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Antinew.ORM.Framework.SqlFilters
{
    public static class FilterExtends
    {
        /// <summary>
        /// 过滤主键
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertiesWithoutPrimaryKey(this Type type)
            => type.GetProperties().Where(p => !p.IsDefined(typeof(AntinewPrimaryKeyAttribute), true));
    }
}
