using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Net.Http;
using ResponseHandler.Abstracts;
using ResponseHandler;

[assembly: FunctionsStartup(typeof(Task1.Function.Startup))]
namespace Task1.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration config = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
            string storageLocation = config["AzureWebJobsStorage"];
            string containerName = config["containerName"];
            string tableName = config["tableName"];
            builder.Services.AddSingleton<HttpClient>(x => new HttpClient());
            builder.Services.AddTransient<IBlobUploader>(x => new BlobUploader(storageLocation, containerName));
            builder.Services.AddTransient<ITableUploader>(x => new TableUploader(storageLocation, tableName));
            builder.Services.AddTransient<IResponseService, ResponseService>(services => new ResponseService(
                services.GetService<ITableUploader>(),
                services.GetService<IBlobUploader>()));
        }
    }
}
