﻿using SmartBoardWebAPI.Data.Models;

namespace SmartBoardWebAPI.Data.Repository
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Get all tasks registered in database
        /// </summary>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetTasksAsync();

        /// <summary>
        /// Get tasks registered in database by sectionId
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetTasksBySectionIdAsync(long sectionId);

        /// <summary>
        /// Get active tasks registered in database by sectionId
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetActiveTasksBySectionIdAsync(long sectionId);

        /// <summary>
        /// Get all tasks registered in database
        /// </summary>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<IEnumerable<TaskModel>> GetActiveTasksAsync();

        /// <summary>
        /// Get task registered in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IEnumerable<TaskModel></returns>
        Task<TaskModel> GetTaskByIdAsync(long id);
    }
}