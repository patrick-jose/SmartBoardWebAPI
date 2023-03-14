using System;
namespace SmartBoardWebAPI.Data.DTOs
{
	public class TaskDTO
	{
        public long Id { get; set; }
        public UserDTO Creator { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateCreation { get; set; }
        public long SectionId { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public UserDTO? Assignee { get; set; }
        public long Position { get; set; }
		public IEnumerable<CommentDTO>? Comments { get; set; }
		public IEnumerable<StatusHistoryDTO>? StatusHistory { get; set; }
    }
}

