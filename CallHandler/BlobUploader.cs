using Azure.Data.Tables;
using Azure.Storage.Blobs;
using ResponseHandler.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseHandler
{
    public class BlobUploader : IBlobUploader
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public BlobUploader(string storageLocation, string containerName)
        {
            _containerName = containerName;
            _blobServiceClient = new BlobServiceClient(storageLocation);
        }

        public async Task Upload(string payload, string logId)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();

            BlobClient blobClient = containerClient.GetBlobClient($"{logId}.json");

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(payload)))
            {
                await blobClient.UploadAsync(ms);
            }
        }
    }
}
