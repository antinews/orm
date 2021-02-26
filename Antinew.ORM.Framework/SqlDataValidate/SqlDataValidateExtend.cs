using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Antinew.ORM.Framework.SqlDataValidate
{
    public static class SqlDataValidateExtend
    {
        public static bool Validate<T>(this T t)
        {
            var type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                var value = prop.GetValue(t);
                if (prop.IsDefined(typeof(AbstractModelValidate), true))
                {
                    var attrs = prop.GetCustomAttributes<AbstractModelValidate>();
                    foreach (var attr in attrs)
                    {
                        if (!attr.Validate(value)) return false;

                    }
                }

            }
            return true;
        }
    }
}
