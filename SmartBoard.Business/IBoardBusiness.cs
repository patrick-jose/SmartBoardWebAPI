using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Business
{
    public interface IBoardBusiness
    {
        /// <summary>
        /// Get all active boards
        /// </summary>
        /// <param name="filled">Flag to get filled boards</param>
        /// <returns>IEnumerable<BoardModel></returns>
        Task<List<BoardDTO>> GetActiveBoardsAsync(bool filled);

        /// <summary>
        /// Get all active boards as database model
        /// </summary>
        /// <param name="filled">Flag to get filled boards</param>
        /// <returns>IEnumerable<BoardModel></returns>
        Task<IEnumerable<BoardModel>> GetActiveBoardsModelAsync(bool filled);
    }
}