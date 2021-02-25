using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Antinew.ORM.Framework.SqlMapping
{
    public static class MappingExtends
    {
        /// <summary>
        /// 面向父类
        /// </summary>
        /// <param name="member">支持Type、PropertyInfo</param>
        /// <returns></returns>
        public static string GetMappingName(this MemberInfo member)
        {
            if (member.IsDefined(typeof(AntinewAbstractMappingAttribute), true))
            {
                var attribute = member.GetCustomAttribute<AntinewAbstractMappingAttribute>();
                return attribute.GetName();
            }
            return member.Name;
        }

        public static string GetTableName(this Type type)
        {
            if (type.IsDefined(typeof(AntinewTableAttribute), true))
            {
                //AntinewTableAttribute attribute = type.GetCustomAttribute(typeof(AntinewTableAttribute)) as AntinewTableAttribute;
                AntinewTableAttribute attribute = type.GetCustomAttribute<AntinewTableAttribute>();
                return attribute.GetName();
            }
            return type.Name;
        }
        public static string GetColumnName(this PropertyInfo property)
        {
            if (property.IsDefined(typeof(AntinewColumnAttribute), true))
            {
                AntinewColumnAttribute attribute = property.GetCustomAttribute<AntinewColumnAttribute>();
                return attribute.GetName();
            }
            return property.Name;
        }
    }
}
