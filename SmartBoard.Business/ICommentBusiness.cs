using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface ICommentBusiness
    {
        /// <summary>
        /// Get comments by task id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>List<CommentDTO></returns>
        Task<List<CommentDTO>> GetCommentsByTaskIdAsync(long taskId);

        /// <summary>
        /// Insert new comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task PostCommentAsync(CommentDTO comment);
    }
}