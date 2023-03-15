using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface ITaskBusiness
    {
        /// <summary>
        /// Get all task by section
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="filled"></param>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetTaskBySectionIdAsync(long sectionId, bool filled);

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <param name="filled"></param>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetTasksAsync(bool filled);

        /// <summary>
        /// Get all active task by section
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="filled"></param>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetActiveTaskBySectionIdAsync(long sectionId, bool filled);

        /// <summary>
        /// Get all active tasks
        /// </summary>
        /// <param name="filled"></param>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetActiveTasksAsync(bool filled);

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filled"></param>
        /// <returns>TaskDTO</returns>
        Task<TaskDTO> GetTaskByIdAsync(long id, bool filled);
    }
}