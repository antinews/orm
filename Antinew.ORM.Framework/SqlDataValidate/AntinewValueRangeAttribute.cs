using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlDataValidate
{
    public class AntinewValueRangeAttribute: AbstractModelValidate
    {
        private Type type;
        //private int _min_int, _max_int;
        //private float _min_float, _max_float;
        //private decimal _min_decimal, _max_decimal;
        //private double _min_double, _max_double;
        private object _min, _max;

        public AntinewValueRangeAttribute(int min, int max)
        {
            type = typeof(int);
            _min = min;
            _max = max;
        }
        public AntinewValueRangeAttribute(float min, float max)
        {
            type = typeof(float);
            _min = min;
            _max = max;
        }
        public AntinewValueRangeAttribute(decimal min, decimal max)
        {
            type = typeof(decimal);
            _min = min;
            _max = max;
        }
        public AntinewValueRangeAttribute( double min, double max)
        {
            type = typeof(double);
            _min = min;
            _max = max;
        }

        public override bool Validate(object obj)
        {
            if (obj is null) return false;
            var val = Convert.ChangeType(obj, type);
            if (type == typeof(int)) return (int)_min <= (int)val && (int)val <= (int)_max;
            if (type == typeof(float)) return (float)_min <= (float)val && (float)val <= (float)_max;
            if (type == typeof(double)) return (double)_min <= (double)val && (double)val <= (double)_max;
            if (type == typeof(decimal)) return (decimal)_min <= (decimal)val && (decimal)val <= (decimal)_max;
            return true;
        }
    }
}
