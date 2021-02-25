using Antinew.ORM.Framework.SqlFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Model.DbModel
{
    /// <summary>
    /// 声明是表
    /// </summary>
    public class BaseModel
    {
        [AntinewPrimaryKeyAttribute]
        public int Id { get; set; }
    }
}
