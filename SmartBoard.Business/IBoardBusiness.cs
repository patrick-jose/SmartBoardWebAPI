using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Business
{
    public interface IBoardBusiness
    {
        Task<List<BoardDTO>> GetActiveBoardsAsync();

        Task<IEnumerable<BoardModel>> GetActiveBoardsModelAsync();
    }
}