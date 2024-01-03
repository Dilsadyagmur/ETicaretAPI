using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance
{
    static class Configuration
    {

        static public string ConnectionString
        {
            get
            {

                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../ETicaretAPI.API"));
                configurationManager.AddJsonFile("appsettings.Json");

                return configurationManager.GetConnectionString("PostgreSql");
            }
        }
    }
}
