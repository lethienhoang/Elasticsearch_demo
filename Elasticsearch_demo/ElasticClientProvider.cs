using Elasticsearch_demo.Models;
using Elasticsearch_demo.Settings;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elasticsearch_demo
{
    public static class ElasticClientProvider
    {
        public static ElasticClient GetElasticClientProviders()
        {

            var connSetting = new ConnectionSettings(new Uri("https://3755bae52cf94f0aaa116ac1fc3a0ad0.ap-southeast-1.aws.found.io:9243/"))
                .DefaultIndex("apm")
                .EnableHttpCompression()
                .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
                .EnableDebugMode()
                .BasicAuthentication("elastic", "I7O3Ukcg2wvTSULn6LYUHK7F");
            //.ApiKeyAuthentication();


            var ElasticClient = new ElasticClient(connSetting);

            return ElasticClient;
        }
    }
}
