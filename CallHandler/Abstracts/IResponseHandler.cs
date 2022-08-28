namespace ResponseHandler.Abstracts
{
    public interface IResponseService
    {
        Task ProcessAsync(HttpResponseMessage message);
    }
}