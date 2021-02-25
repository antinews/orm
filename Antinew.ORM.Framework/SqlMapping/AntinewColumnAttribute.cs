using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlMapping
{
    /// <summary>
    /// 列名映射
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AntinewColumnAttribute:AntinewAbstractMappingAttribute
    {
        //private string _name;
        //public AntinewColumnAttribute(string columnName)
        //{
        //    this._name = columnName;
        //}
        //public string GetName() => this._name;
        public AntinewColumnAttribute(string tableName):base(tableName)
        {

        }
    }
}
