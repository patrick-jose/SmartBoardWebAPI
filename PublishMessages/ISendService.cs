using SmartBoardWebAPI.Utils;

namespace PublishMessages
{
    public interface ISendService
    {
        Task<bool> SendMessage(string json, Header header);
    }
}