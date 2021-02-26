using System;
using System.Collections.Generic;
using System.Text;
using Antinew.ORM.Framework.SqlDataValidate;
using Antinew.ORM.Framework.SqlMapping;

namespace Antinew.ORM.Model.DbModel
{
    [AntinewTable("User")]
    public class UserModel : BaseModel
    {
        [AntinewColumn("UserName")]
        [AntinewLength(2, 12), AntinewRequired]
        public string UserName { get; set; }
        [AntinewValueRangeAttribute(1,120)]
        public int? UserAge { get; set; }
        public int? UserSex { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }

    }
}
