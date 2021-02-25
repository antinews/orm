using Antinew.ORM.Framework.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antinew.ORM.Framework.Configuration
{
    public class ConnectionStringProvider
    {
        private static int _seed;
        public static string GetConnectionString(DBOperation operation, SlaveStrategy strategy = SlaveStrategy.Average)
        {
            switch (operation)
            {
                case DBOperation.Read:
                    return GetReadConnectionString(strategy);
                case DBOperation.Write:
                    return Configurations.WriteConnectionString;
                default:
                    throw new Exception("Wrong operation");
            }
        }

        private static string GetReadConnectionString(SlaveStrategy strategy)
        {
            var slaves = Configurations.ReadConnectionString;
            int count = slaves.Length;
            switch (strategy)
            {
                case SlaveStrategy.Average:
                    return slaves[new Random(_seed++).Next(0, count)];
                case SlaveStrategy.Weighting:
                    throw new Exception("Temporary unrealized");
                case SlaveStrategy.Polling:
                    return slaves[_seed++ % count];
                default:
                    throw new Exception("Wrong strategy");
            }
        }
    }
}
