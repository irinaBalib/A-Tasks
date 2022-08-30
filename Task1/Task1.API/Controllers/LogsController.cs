using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using Azure.Data.Tables;
using Azure;
using Data;

namespace Task1.API.Controllers
{

    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly HttpClient _http;
        private readonly TableClient _tableClient;

        public LogsController(HttpClient http, TableClient tableClient)
        {
            _http = http;
            _tableClient = tableClient;
        }

        [HttpGet("/Logs")]
        public Pageable<Data.LogMessage> Get(DateTime from, DateTime to)
        {
            Pageable<Data.LogMessage> queryResults = _tableClient.Query<Data.LogMessage>(l => l.Timestamp >= from && l.Timestamp <= to);
            return queryResults;
        }
    }
}
