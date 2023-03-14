using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface IStatusHistoryRepository
    {
        Task<IEnumerable<StatusHistoryModel>> GetStatusHistoryByTaskIdAsync(long taskId);
        Task<IEnumerable<StatusHistoryModel>> GetStatusHistorysAsync();
    }
}