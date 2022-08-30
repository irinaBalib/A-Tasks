using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Data;
using ResponseHandler.Abstracts;

namespace ResponseHandler
{
    public class TableUploader : ITableUploader
    {
        private readonly TableServiceClient _tableServiceClient;
        private readonly string _tableName;

        public TableUploader(string storageLocation, string tableName)
        {
            _tableServiceClient = new TableServiceClient(storageLocation);
            _tableName = tableName;
        }

        public async Task Upload(LogMessage message)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(_tableName);

            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync<LogMessage>(message);
        }
    }
}
