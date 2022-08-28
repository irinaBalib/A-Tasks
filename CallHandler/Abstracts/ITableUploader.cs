using Data;

namespace ResponseHandler.Abstracts
{
    public interface ITableUploader
    {
        Task Upload(LogMessage message);
    }
}