using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Antinew.ORM.Framework.Configuration
{
    /// <summary>
    /// 固定读取根目录下的appsetting.json
    /// </summary>
    public class Configurations
    {
        private static string _writeConnectionString;
        private static string[] _readConnectionStrings;
        public static string WriteConnectionString { get { return _writeConnectionString; } }
        public static string[] ReadConnectionString { get { return _readConnectionStrings; } }
        static Configurations()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json");

            IConfigurationRoot configuration = builder.Build();
            _writeConnectionString = configuration["ConnectionStrings:Master"];
            _readConnectionStrings = configuration.GetSection("ConnectionStrings").GetSection("Slaves").GetChildren().Select(x=>x.Value).ToArray();
        }
    }
}
