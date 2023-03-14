using System;
namespace SmartBoardWebAPI.Data.DTOs
{
	public class SectionDTO
	{
        public long Id { get; set; }
        public string Name { get; set; }
		public bool Active { get; set; }
		public long Position { get; set; }
		public IEnumerable<TaskDTO> Tasks { get; set; }
	}
}

