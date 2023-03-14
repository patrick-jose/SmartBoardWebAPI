using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Get all comments registered in database
        /// </summary>
        /// <returns>IEnumerable<CommentModel></returns>
        Task<IEnumerable<CommentModel>> GetCommentsAsync();

        /// <summary>
        /// Get comments registered in database by taskId
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>IEnumerable<CommentModel></returns>
        Task<IEnumerable<CommentModel>> GetCommentsByTaskIdAsync(long taskId);
    }
}