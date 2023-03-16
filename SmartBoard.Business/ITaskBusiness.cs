using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface ITaskBusiness
    {
        /// <summary>
        /// Get all task by section
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetTaskBySectionIdAsync(long sectionId);

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetTasksAsync();

        /// <summary>
        /// Get all active task by section
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetActiveTaskBySectionIdAsync(long sectionId);

        /// <summary>
        /// Get all active tasks
        /// </summary>
        /// <returns>List<TaskDTO></returns>
        Task<List<TaskDTO>> GetActiveTasksAsync();

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TaskDTO</returns>
        Task<TaskDTO> GetTaskByIdAsync(long id);

        /// <summary>
        /// Insert new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task PostTaskAsync(TaskDTO task);

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task PutTaskAsync(TaskDTO task);

        /// <summary>
        /// Update multiple tasks
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        Task PutTasksAsync(List<TaskDTO> tasks);
    }
}