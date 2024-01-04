using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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


                Microsoft.Extensions.Configuration.ConfigurationManager configurationManager = new ();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                configurationManager.AddJsonFile("appsettings.Json");

                return configurationManager.GetConnectionString("PostgreSql");
            }

        }
    }
}
