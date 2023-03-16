using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Models
{
	public class StatusHistoryModel
	{
		public long UserId { get; set; }
		public long TaskId { get; set; }
		public long PreviousSectionId { get; set; }
        public long ActualSectionId { get; set; }
        public DateTime DateModified { get; set; }

        public async Task<StatusHistoryDTO> ToDTO()
        {
            return new StatusHistoryDTO()
            {
                TaskId = this.TaskId,
                ActualSectionId = this.ActualSectionId,
                DateModified = this.DateModified,
                PreviousSectionId = this.PreviousSectionId,
                UserId = this.UserId
            };
        }
    }
}

