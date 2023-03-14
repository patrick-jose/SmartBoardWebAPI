using System;
namespace SmartBoardWebAPI.Data.Models
{
	public class StatusHistoryModel
	{
		public long UserId { get; set; }
		public long TaskId { get; set; }
		public long PreviousSectionId { get; set; }
        public long ActualSectionId { get; set; }
        public DateTime DateModified { get; set; }
	}
}

