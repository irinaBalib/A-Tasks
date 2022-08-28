using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ResponseHandler.Abstracts;

namespace Task1.Function
{
    public class RandomCall
    {
        private readonly HttpClient _http;
        private readonly IResponseService _service;
        public RandomCall(HttpClient httpClient, IResponseService service)
        {
            _http = httpClient;
            _service = service;
        }

        [FunctionName("RandomCall")]
        public async Task RunAsync([TimerTrigger("* * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            HttpResponseMessage response = await _http.GetAsync(Endpoint.Random);

            await _service.ProcessAsync(response);

        }
    }
}
