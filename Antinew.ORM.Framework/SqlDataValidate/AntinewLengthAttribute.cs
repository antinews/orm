using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlDataValidate
{
    public class AntinewLengthAttribute:Attribute
    {
        private int _min = 0, _max = 0;
        public AntinewLengthAttribute(int min, int max)
        {
            this._min = min;
            this._max = max;
        }
        public bool Validate(object obj)
        {
            if (obj is null) return false;
            int length = obj.ToString().Length;
            return length <= _max && length >= 0;
        }
    }
}
