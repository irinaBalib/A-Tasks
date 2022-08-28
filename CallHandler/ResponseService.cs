using System;
using Data;
using ResponseHandler.Abstracts;

namespace ResponseHandler
{
    public class ResponseService : IResponseService
    {
        private ITableUploader _tableUploader;
        private IBlobUploader _blobUploader;

        public ResponseService(ITableUploader tableUploader, IBlobUploader blobUploader)
        {
            _tableUploader = tableUploader;
            _blobUploader = blobUploader;
        }

        public async Task ProcessAsync(HttpResponseMessage response)
        {
            var status = response.StatusCode.ToString();
            var logId = await SaveLog(status);

            var content = await response.Content.ReadAsStringAsync();
            await SavePayload(content, logId);

        }
        private async Task<string> SaveLog(string status)
        {
            var logMessage = new LogMessage()
            {
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = DateTime.Now.ToString("yy-MM-dd"),
                Message = status
            };
            await _tableUploader.Upload(logMessage);

            return logMessage.RowKey;
        }

        private async Task SavePayload(string? content, string logId)
        {
            content = content ?? string.Empty;
            await _blobUploader.Upload(content, logId);
        } 
    }
}