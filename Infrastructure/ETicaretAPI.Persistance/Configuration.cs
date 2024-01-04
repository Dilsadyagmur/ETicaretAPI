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
        public string ConnectionString
        {
            get
            {

                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API");
                configurationManager.AddJsonFile("secret.json");

                return configurationManager.GetConnectionString("");
            }

        }
    }
}
