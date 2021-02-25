using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Antinew.ORM.Framework
{
    /// <summary>
    /// 固定读取根目录下的appsetting.json
    /// </summary>
    public class Configurations
    {
        private static string _sqlConnectionString;
        public static string SqlConnectionString { get { return _sqlConnectionString; } }
        static Configurations()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json");

            IConfigurationRoot configuration = builder.Build();
            _sqlConnectionString = configuration["connectionString"];
        }
    }
}
