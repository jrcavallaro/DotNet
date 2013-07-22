using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationServer.Caching;

namespace HelloAppFabric
{
    public class CashUtil
    {
        private static DataCacheFactory _factory = null;
        private static DataCache _cache = null;

        public static DataCache GetCache()
        {
            if (_cache != null)
            {
                return _cache;
            }

            //Define Array for 1 Cache Host
            var servers = new List<DataCacheServerEndpoint>(1);

            //Specify Cache Host Details 
            //  Parameter 1 = host name
            //  Parameter 2 = cache port number
            servers.Add(new DataCacheServerEndpoint("DevMongoDB2", 22233));

            //Create cache configuration
            var configuration = new DataCacheFactoryConfiguration
                {
                    Servers = servers,
                    LocalCacheProperties = new DataCacheLocalCacheProperties()
                };

            //Disable tracing to avoid informational/verbose messages on the web page
            DataCacheClientLogManager.ChangeLogLevel(System.Diagnostics.TraceLevel.Off);

            //Pass configuration settings to cacheFactory constructor

            //_factory = new DataCacheFactory(configuration);
            _factory = new DataCacheFactory(configuration: configuration);
            
            //Get reference to named cache called "default"
            _cache = _factory.GetCache("default");

            return _cache;
        }
    }
}
