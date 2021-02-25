using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.SqlMapping
{
    public abstract class AntinewAbstractMappingAttribute:Attribute
    {
        private string _name;
        public AntinewAbstractMappingAttribute(string name)
        {
            this._name = name;
        }
        public string GetName() => this._name;
    }
}
