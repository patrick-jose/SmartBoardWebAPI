using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface IBoardRepository
    {
        /// <summary>
        /// Get all boards with complete information
        /// </summary>
        /// <param name="filled">Flag to get filled boards</param>
        /// <returns>IEnumerable<BoardModel></returns>
        Task<IEnumerable<BoardModel>> GetBoardsAsync(bool filled);

        /// <summary>
        /// Get active boards with complete information
        /// </summary>
        /// <param name="filled">Flag to get filled boards</param>
        /// <returns>IEnumerable<BoardModel></returns>
        Task<IEnumerable<BoardModel>> GetActiveBoardsAsync(bool filled);
    }
}