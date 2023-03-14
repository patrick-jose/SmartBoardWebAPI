using System;
namespace SmartBoardWebAPI.Data.DTOs
{
	public class StatusHistoryDTO
	{
		public UserDTO User { get; set; }
		public SectionDTO PreviousSection { get; set; }
        public SectionDTO ActualSection { get; set; }
        public DateTime DateModified { get; set; }
    }
}

