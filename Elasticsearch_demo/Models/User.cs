using System;

namespace Elasticsearch_demo.Models
{
    public class User 
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }
    }
}
