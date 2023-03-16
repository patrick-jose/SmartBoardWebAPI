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
        public async Task<List<TaskDTO>> GetAllTasks()
        {
            return await _taskBusiness.GetTasksAsync();
        }

        /// <summary>
        /// Get all tasks by task
        /// </summary>
        /// <returns>List<TaskModel></returns>
        [HttpGet("GetAllTasksBySectionId/")]
        public async Task<List<TaskDTO>> GetAllTasksBySectionId(long taskId)
        {
            return await _taskBusiness.GetTaskBySectionIdAsync(taskId);
        }

        /// <summary>
        /// Get all active tasks
        /// </summary>
        /// <returns>List<TaskDTO></returns>
        [HttpGet("GetAllActiveTasks/")]
        public async Task<List<TaskDTO>> GetAllActiveTasks()
        {
            return await _taskBusiness.GetActiveTasksAsync();
        }

        /// <summary>
        /// Get all active tasks by task
        /// </summary>
        /// <returns>List<TaskModel></returns>
        [HttpGet("GetAllActiveTasksBySectionId/")]
        public async Task<List<TaskDTO>> GetAllActiveTasksBySectionId(long taskId)
        {
            return await _taskBusiness.GetActiveTaskBySectionIdAsync(taskId);
        }

        /// <summary>
        /// Get all active tasks by task
        /// </summary>
        /// <returns>List<TaskModel></returns>
        [HttpGet("GetTaskById/")]
        public async Task<TaskDTO> GetTaskId(long id)
        {
            return await _taskBusiness.GetTaskByIdAsync(id);
        }

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<ActionResult> PutTask(TaskDTO task)
        {
            await _taskBusiness.PutTaskAsync(task);

            return Ok();
        }

        /// <summary>
        /// Update tasks
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut("Multiple/")]
        public async Task<ActionResult> PutTasks(List<TaskDTO> task)
        {
            await _taskBusiness.PutTasksAsync(task);

            return Ok();
        }

        /// <summary>
        /// Insert new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult> PostTask([FromBody] TaskDTO task)
        {
            await _taskBusiness.PostTaskAsync(task);

            return Ok();
        }
    }
}

