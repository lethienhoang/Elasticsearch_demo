using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Elasticsearch_demo.Models;
using Elasticsearch_demo.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Elasticsearch_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticSearchController : ControllerBase
    {
        private readonly IElasticClient _client;
        // /api/elasticsearch
        public ElasticSearchController()
        {
            _client = ElasticClientProvider.GetElasticClientProviders();
        }

        [HttpGet]
        public IActionResult Get()
        {

            var indexExistsRequest = new IndexExistsRequest("myindex");
            var isExists = _client.Indices.Exists(indexExistsRequest).Exists;

            if (!isExists)
            {
                _client.Indices.Create("myindex", c => c
                 .Map<Document>(m => m
                     .AutoMap<Company>()
                     .AutoMap(typeof(Employee))
                    )
                );
            }


            var parentDocument = new Company
            {
                Employees =  new List<Employee>
                {
                    new Employee
                    {
                        Birthday = DateTime.Now,
                        Hours = DateTime.Now.TimeOfDay,
                        IsManager = true,
                        LastName = "aa324234",
                        Salary = 3,
                    }
                },
                Name = "bbb"
               
            };

            var indexParent = _client.Index(parentDocument, i => i.Index("myindex").Id(parentDocument.Name).Refresh(Refresh.True));

            var respone = _client.Search<Employee>(x => x.Index("myindex"));
            return Ok(respone);
        }

        public abstract class Document
        {
            public JoinField Join { get; set; }
        }

        public class Company : Document
        {
            public string Name { get; set; }
            public List<Employee> Employees { get; set; }
        }

        public class Employee : Document
        {
            public string LastName { get; set; }
            public int Salary { get; set; }
            public DateTime Birthday { get; set; }
            public bool IsManager { get; set; }
            //public List<Employee> Employees { get; set; }
            public TimeSpan Hours { get; set; }
        }
    }
}