using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Get all tasks registered in database
        /// </summary>
        /// <param name="filled">Flag to return filled tasks</param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetTasksAsync(bool filled);

        /// <summary>
        /// Get tasks registered in database by sectionId
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="filled">Flag to return filled tasks</param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetTasksBySectionIdAsync(long sectionId, bool filled);

        /// <summary>
        /// Get active tasks registered in database by sectionId
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="filled">Flag to return filled tasks</param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetActiveTasksBySectionIdAsync(long sectionId, bool filled);

        /// <summary>
        /// Get all tasks registered in database
        /// </summary>
        /// <param name="filled">Flag to return filled tasks</param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetActiveTasksAsync(bool filled);

        /// <summary>
        /// Get task registered in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filled">Flag to return filled tasks</param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<TaskModel> GetTaskByIdAsync(long id, bool filled);
    }
}