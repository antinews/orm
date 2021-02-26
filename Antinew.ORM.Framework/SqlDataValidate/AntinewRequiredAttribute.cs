using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlDataValidate
{
    public class AntinewRequiredAttribute : AbstractModelValidate
    {
        public override bool Validate(object obj)
        {
            if (obj is null) return false;
            return string.IsNullOrWhiteSpace(obj.ToString());
    }
}
