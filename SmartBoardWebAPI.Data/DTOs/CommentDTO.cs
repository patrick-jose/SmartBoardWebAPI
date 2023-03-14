using System;
namespace SmartBoardWebAPI.Data.Models
{
	public class CommentModel
	{
		public long Id { get; set; }
		public long TaskId { get; set; }
		public long WriterId { get; set; }
		public string Content { get; set; }
		public DateTime DateCreation { get; set; }
	}
}

