using Azure.Data.Tables;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage.Blob;
using Data;

namespace Task1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        private readonly HttpClient _http;
       // private readonly BlobClient _blobClient;

        public PayloadController(HttpClient http)
        {
            _http = http;
        }

        [HttpGet("/Payload/{id}")]
        public async Task<string> GetAsync(string id)
        {
            HttpResponseMessage msg = await _http.GetAsync($"http://127.0.0.1:10000/devstoreaccount1/mycontainer/{id}.json");
            return await msg.Content.ReadAsStringAsync();
        }
    }
}
