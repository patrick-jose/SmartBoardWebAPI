using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface IBoardRepository
    {
        Task<IEnumerable<BoardModel>> GetBoardsAsync();
    }
}