using System;
namespace SmartBoardWebAPI.Data.Models
{
	public class TaskModel
	{
		public long Id { get; set; }
		public long CreatorId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateCreation { get; set; }
        public long SectionId { get; set; }
        public bool Active { get; set; }
        public long AssigneeId { get; set; }
        public long Position { get; set; }
		public IEnumerable<CommentModel> Comments { get; set; }
    }
}

