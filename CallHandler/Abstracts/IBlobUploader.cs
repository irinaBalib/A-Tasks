namespace ResponseHandler.Abstracts
{
    public interface IBlobUploader
    {
        Task Upload(string payload, string logId);
    }
}