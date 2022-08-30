using DB;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IDbService _dbService;

        public HomeController(ILogger<HomeController> logger/*, IDbService dbService*/)
        {
            _logger = logger;
           // _dbService = dbService;
        }

        public IActionResult Index()
        {
            //Get list of entries from DB _dbService.Get
            // Serialize to domain models
            // ViewData["GraphData"] = GetGraphData(models);
            // return View("Index", models)
            // ?? Not sure how to tackle two graphs at the same output

            return View();
        }

        private List<GraphDataPoint> GetGraphData(List<WeatherItem> models)
        {
            // create graph datapoints by applying models data 

            throw new NotImplementedException();
        }

    }
}