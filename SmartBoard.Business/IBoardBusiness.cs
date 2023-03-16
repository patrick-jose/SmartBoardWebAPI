using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Business
{
    public interface IBoardBusiness
    {
        /// <summary>
        /// Get all active boards
        /// </summary>
        /// <returns>IEnumerable<BoardModel></returns>
        Task<List<BoardDTO>> GetActiveBoardsAsync();

        /// <summary>
        /// Insert new board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        Task PostBoardAsync(BoardDTO board);

        /// <summary>
        /// Update board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        Task PutBoardAsync(BoardDTO board);
    }
}