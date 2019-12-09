using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elasticsearch_demo.Settings
{
    public class AWSSettings
    {
        public string ElasticUrl { get; set; }

        public string UserName { get; set; }
        
        public string Password { get; set; }

        public string AccessKey { get; set; }

        public string DefaultIndex { get; set; }
    }
}
