using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlFilters
{
    /// <summary>
    /// 主键标识
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AntinewPrimaryKeyAttribute:Attribute
    {
    }
}
