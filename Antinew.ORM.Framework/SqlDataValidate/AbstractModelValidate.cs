using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlDataValidate
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class AbstractModelValidate:Attribute
    {
        public abstract bool Validate(object obj);
    }
}
