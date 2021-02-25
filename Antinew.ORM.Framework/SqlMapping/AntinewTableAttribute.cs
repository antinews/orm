using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlMapping
{
    /// <summary>
    /// 数据库表名映射
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]  // 只允许修饰类
    public class AntinewTableAttribute:AntinewAbstractMappingAttribute
    {
        //private string _name;
        //public AntinewTableAttribute(string tableName)
        //{
        //    this._name = tableName;
        //}
        //public string GetName() => _name;

        public AntinewTableAttribute(string tableName):base(tableName)
        {
        }
    }
}
