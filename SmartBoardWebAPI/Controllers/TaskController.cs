using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartTaskWebAPI.Controllers
{
    /// <summary>
    /// Tasks informations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskBusiness _taskBusiness;

        public TaskController(ITaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns>List<TaskDTO></returns>
        [HttpGet("GetAllTasks/")]
        public async Task<List<TaskDTO>> GetAllTasks(bool filled)
        {
            return await _taskBusiness.GetTasksAsync(filled);
        }

        /// <summary>
        /// Get all tasks by section
        /// </summary>
        /// <returns>List<TaskModel></returns>
        [HttpGet("GetAllTasksBySectionId/")]
        public async Task<List<TaskDTO>> GetAllTasksBySectionId(long sectionId, bool filled)
        {
            return await _taskBusiness.GetTaskBySectionIdAsync(sectionId, filled);
        }

        /// <summary>
        /// Get all active tasks
        /// </summary>
        /// <returns>List<TaskDTO></returns>
        [HttpGet("GetAllActiveTasks/")]
        public async Task<List<TaskDTO>> GetAllActiveTasks(bool filled)
        {
            return await _taskBusiness.GetActiveTasksAsync(filled);
        }

        /// <summary>
        /// Get all active tasks by section
        /// </summary>
        /// <returns>List<TaskModel></returns>
        [HttpGet("GetAllActiveTasksBySectionId/")]
        public async Task<List<TaskDTO>> GetAllActiveTasksBySectionId(long sectionId, bool filled)
        {
            return await _taskBusiness.GetActiveTaskBySectionIdAsync(sectionId, filled);
        }

        /// <summary>
        /// Get all active tasks by section
        /// </summary>
        /// <returns>List<TaskModel></returns>
        [HttpGet("GetTaskById/")]
        public async Task<TaskDTO> GetTaskId(long id, bool filled)
        {
            return await _taskBusiness.GetTaskByIdAsync(id, filled);
        }
    }
}

