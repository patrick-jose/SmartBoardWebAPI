﻿using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Business
{
    public interface IStatusHistoryBusiness
    {
        /// <summary>
        /// Get status history list by task id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>List<StatusHistoryDTO></returns>
        Task<List<StatusHistoryDTO>> GetStatusHistoryByTaskIdAsync(long taskId);
    }
}