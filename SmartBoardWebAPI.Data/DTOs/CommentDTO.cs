using System;
namespace SmartBoardWebAPI.Data.DTOs
{
	public class CommentDTO
	{
        public long Id { get; set; }
        public UserDTO Writer { get; set; }
		public string Content { get; set; }
		public DateTime DateCreation { get; set; }
		public long TaskId { get; set; }
	}
}

