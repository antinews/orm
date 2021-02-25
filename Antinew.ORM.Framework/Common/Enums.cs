using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.Common
{
    public enum DBOperation
    {
        Read,Write
    }
    public enum SlaveStrategy
    {
        Average, Weighting, Polling
    }
}
