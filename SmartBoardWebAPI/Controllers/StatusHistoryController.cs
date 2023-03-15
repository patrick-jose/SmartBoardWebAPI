using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Models;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartBoardWebAPI.Controllers
{
    /// <summary>
    /// Boards informations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatusHistoryController : ControllerBase
    {
        private readonly IStatusHistoryBusiness _statusHistoryBusiness;

        public StatusHistoryController(IStatusHistoryBusiness statusHistoryBusiness)
        {
            _statusHistoryBusiness = statusHistoryBusiness;
        }

        /// <summary>
        /// Get status history by task id
        /// </summary>
        /// <returns>List<StatusHistoryDTO></returns>
        [HttpGet("GetStatusHistoryByTaskId/")]
        public async Task<List<StatusHistoryDTO>> GetStatusHistoryByTaskId(long taskId)
        {
            return await _statusHistoryBusiness.GetStatusHistoryByTaskIdAsync(taskId);
        }
    }
}

