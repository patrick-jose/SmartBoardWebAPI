using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface IBoardRepository
    {
        /// <summary>
        /// Get all boards with complete information
        /// </summary>
        /// <returns>IEnumerable<BoardModel></returns>
        Task<IEnumerable<BoardModel>> GetBoardsAsync();

        /// <summary>
        /// Get active boards with complete information
        /// </summary>
        /// <returns>IEnumerable<BoardModel></returns>
        Task<IEnumerable<BoardModel>> GetActiveBoardsAsync();
    }
}